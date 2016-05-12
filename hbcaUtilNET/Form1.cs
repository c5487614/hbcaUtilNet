using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hbcaUtilNET
{
    public partial class Form1 : Form
    {
        IntPtr hProv = IntPtr.Zero;
        IntPtr hHash = IntPtr.Zero;
		byte[] pbPublicKeyData;
        public Form1()
        {
            InitializeComponent();

            u_init();
        }
        private void u_init() 
        {
            try
            {
                tree_list.Nodes.Clear();
                TreeNode rootNode = new TreeNode("CSP PROVIDER");
                List<string> listProvs = Win32Crypt.getAllProviders();
                foreach (string provider in listProvs)
                {
                    TreeNode treeNode = new TreeNode(provider);
                    rootNode.Nodes.Add(treeNode);
                }
                tree_list.Nodes.Add(rootNode);
                rootNode.Expand();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                const uint PROV_RSA_FULL = 0x00000001;
                const uint CRYPT_VERIFYCONTEXT = 0xF0000000; //no private key access required
                hProv = IntPtr.Zero;
                string provider = null;
                provider = "HaiTai Cryptographic Service Provider 20485";
                string container = null;
                uint dwType = PROV_RSA_FULL;
                bool bCsp = Win32Crypt.CryptAcquireContext(ref hProv, container, provider, dwType, CRYPT_VERIFYCONTEXT);
                if (!bCsp)
                {
                    Win32Crypt.showWin32Error(Marshal.GetLastWin32Error());
                    return;
                }
                //get container
                const uint CRYPT_FIRST = 0x00000001;
                const uint PP_ENUMCONTAINERS = 0x00000002;
                const uint PP_SIGNATURE_PIN = 0x00000021;
                const uint PP_ADMIN_PIN = 0x0000001F;
                const uint PP_CONTAINER = 0x00000006;
                const int BUFFERSIZE = 256;
                uint enumFlags = PP_ENUMCONTAINERS;
                //enumFlags = PP_SIGNATURE_PIN;
                StringBuilder sb = new StringBuilder(BUFFERSIZE);
                uint pcbData = BUFFERSIZE;
                uint dwFlags = 0;
                dwFlags = CRYPT_FIRST;
                //enumFlags = PP_CONTAINER;
                //while (Win32Crypt.CryptGetProvParam(hProv, enumFlags, sb, ref pcbData, dwFlags))
                //{
                //    dwFlags = 0;
                //    MessageBox.Show(sb.ToString());
                //    tbox_result.AppendText(sb.ToString() + "\n");

                //}
                //sb = new StringBuilder(BUFFERSIZE);
                //enumFlags = PP_ADMIN_PIN;
                //dwFlags = 0;
                //bool bSucc = Win32Crypt.CryptGetProvParam(hProv, enumFlags, sb, ref pcbData, dwFlags);
                //if (!bSucc)
                //{
                //    Win32Crypt.showWin32Error(Marshal.GetLastWin32Error());
                //    return;
                //}

                //if (hProv != IntPtr.Zero)
                //{
                //    Win32Crypt.CryptReleaseContext(hProv, 0);
                //}
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_createHash_Click(object sender, EventArgs e)
        {
            try
            {
                const uint AlogId = 0x00008004;
                bool bSucc = Win32Crypt.CryptCreateHash(hProv, AlogId, IntPtr.Zero, 0, ref hHash);
                if (!bSucc)
                {
                    MessageBox.Show(Win32Crypt.showWin32Error(Marshal.GetLastWin32Error()));
                    return;
                }
                if (hHash != IntPtr.Zero)
                {
                    MessageBox.Show("创建HASH成功！");
                }
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.ToString());
            }
        }

        private void btn_getCert_Click(object sender, EventArgs e)
        {
            try
            {
                //get container
                const uint AT_SIGNATURE = 0x00000002;
                const uint KP_CERTIFICATE = 26;
                const uint CERT_STORE_CERTIFICATE_CONTEXT = 1;
                const uint X509_ASN_ENCODING = 0x00000001;
                const uint PKCS_7_ASN_ENCODING = 0x00010000;
                uint MY_CERT_ENCODING = X509_ASN_ENCODING | PKCS_7_ASN_ENCODING;
                const uint CERT_NAME_RDN_TYPE = 2;
                const uint CERT_NAME_ATTR_TYPE = 3;
                const uint CERT_NAME_ISSUER_FLAG = 1;
                uint pvTypePara =  3 ;
                uint certLenth = 0;
                IntPtr hUserKey = IntPtr.Zero;
                IntPtr hCertContext = IntPtr.Zero;
                byte[] certStr = null;
                if (hProv == IntPtr.Zero)
                {
                    MessageBox.Show("CSP句柄为空，请先获取CSP句柄");
                    return;
                }
                if (Win32Crypt.CryptGetUserKey(hProv, AT_SIGNATURE, ref hUserKey))
                {
                    Win32Crypt.CryptGetKeyParam(hUserKey, KP_CERTIFICATE, null, ref certLenth, 0);
                    certStr = new byte[certLenth];
                    Win32Crypt.CryptGetKeyParam(hUserKey, KP_CERTIFICATE, certStr, ref certLenth, 0);

                    //hCertContext = Win32Crypt.CertCreateContext(CERT_STORE_CERTIFICATE_CONTEXT, MY_CERT_ENCODING, certStr, certLenth, 1);
                    hCertContext = Win32Crypt.CertCreateCertificateContext(MY_CERT_ENCODING, certStr, certLenth);
                    if (hCertContext != IntPtr.Zero)
                    {
                        
                        uint dataLength = 1280;
                        
                        StringBuilder sbData = new StringBuilder((int)dataLength);
                        Win32Crypt.CertGetNameString(hCertContext, CERT_NAME_RDN_TYPE, 0, ref pvTypePara, sbData, ref dataLength);
                        MessageBox.Show(sbData.ToString());
                        //StringBuilder strOId = new StringBuilder("2.5.4.3");
                        //StringBuilder sbData1 = new StringBuilder((int)dataLength);
                        //Win32Crypt.CertGetNameString(hCertContext, CERT_NAME_RDN_TYPE, CERT_NAME_ATTR_TYPE, strOId, sbData1, ref dataLength);

                    }
                    else
                    {
                        MessageBox.Show(Win32Crypt.showWin32Error(Marshal.GetLastWin32Error()));

                        return;
                    }
                }
                else
                {
                    MessageBox.Show(Win32Crypt.showWin32Error(Marshal.GetLastWin32Error()));
                    
                    return;
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            hProv = IntPtr.Zero;
            hHash = IntPtr.Zero;
        }

        private void btn_test_Click(object sender, EventArgs e)
        {

        }

        private void btn_deleteContainer_Click(object sender, EventArgs e)
        {
            try
            {
                string container = "myContainer";
                bool bCsp = Win32Crypt.CryptAcquireContext(ref hProv, container, CSPParam.HTCSPNAME, CSPParam.PROV_RSA_FULL, CSPParam.CRYPT_DELETEKEYSET);
                MessageBox.Show(Win32Crypt.showWin32Error(Marshal.GetLastWin32Error()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_createContainer_Click(object sender, EventArgs e)
        {
            try
            {
                string container = "myContainer";
                bool bCsp = Win32Crypt.CryptAcquireContext(ref hProv, container, CSPParam.HTCSPNAME, CSPParam.PROV_RSA_FULL, CSPParam.CRYPT_NEWKEYSET);
                MessageBox.Show(Win32Crypt.showWin32Error(Marshal.GetLastWin32Error()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_getCertIssuer_Click(object sender, EventArgs e)
        {
            try
            {
                //get container
                const uint AT_SIGNATURE = 0x00000002;
                const uint KP_CERTIFICATE = 26;
                const uint X509_ASN_ENCODING = 0x00000001;
                const uint PKCS_7_ASN_ENCODING = 0x00010000;
                uint MY_CERT_ENCODING = X509_ASN_ENCODING | PKCS_7_ASN_ENCODING;
                const uint CERT_NAME_RDN_TYPE = 2;
                uint pvTypePara = 3;
                uint certLenth = 0;
                IntPtr hUserKey = IntPtr.Zero;
                IntPtr hCertContext = IntPtr.Zero;
                byte[] certStr = null;
                if (hProv == IntPtr.Zero)
                {
                    MessageBox.Show("CSP句柄为空，请先获取CSP句柄");
                    return;
                }
                if (Win32Crypt.CryptGetUserKey(hProv, AT_SIGNATURE, ref hUserKey))
                {
                    Win32Crypt.CryptGetKeyParam(hUserKey, KP_CERTIFICATE, null, ref certLenth, 0);
                    certStr = new byte[certLenth];
                    Win32Crypt.CryptGetKeyParam(hUserKey, KP_CERTIFICATE, certStr, ref certLenth, 0);

                    hCertContext = Win32Crypt.CertCreateCertificateContext(MY_CERT_ENCODING, certStr, certLenth);
                    if (hCertContext != IntPtr.Zero)
                    {

                        uint dataLength = 1280;

                        StringBuilder sbData = new StringBuilder((int)dataLength);
                        Win32Crypt.CertGetNameString(hCertContext, CERT_NAME_RDN_TYPE, CSPParam.CERT_NAME_ISSUER_FLAG, ref pvTypePara, sbData, ref dataLength);
                        MessageBox.Show(sbData.ToString());

                    }
                    else
                    {
                        MessageBox.Show(Win32Crypt.showWin32Error(Marshal.GetLastWin32Error()));

                        return;
                    }
                }
                else
                {
                    MessageBox.Show(Win32Crypt.showWin32Error(Marshal.GetLastWin32Error()));

                    return;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_getCertProp_Click(object sender, EventArgs e)
        {
            try
            {
                //get container
                const uint AT_SIGNATURE = 0x00000002;
                const uint KP_CERTIFICATE = 26;
                const uint X509_ASN_ENCODING = 0x00000001;
                const uint PKCS_7_ASN_ENCODING = 0x00010000;
                uint MY_CERT_ENCODING = X509_ASN_ENCODING | PKCS_7_ASN_ENCODING;
                const uint CERT_NAME_RDN_TYPE = 2;
                uint pvTypePara = 3;
                uint certLenth = 0;
                IntPtr hUserKey = IntPtr.Zero;
                IntPtr hCertContext = IntPtr.Zero;
                byte[] certStr = null;
                if (hProv == IntPtr.Zero)
                {
                    MessageBox.Show("CSP句柄为空，请先获取CSP句柄");
                    return;
                }
                if (Win32Crypt.CryptGetUserKey(hProv, AT_SIGNATURE, ref hUserKey))
                {
                    Win32Crypt.CryptGetKeyParam(hUserKey, KP_CERTIFICATE, null, ref certLenth, 0);
                    certStr = new byte[certLenth];
                    Win32Crypt.CryptGetKeyParam(hUserKey, KP_CERTIFICATE, certStr, ref certLenth, 0);

                    hCertContext = Win32Crypt.CertCreateCertificateContext(MY_CERT_ENCODING, certStr, certLenth);
                    if (hCertContext != IntPtr.Zero)
                    {
                        uint uLength =40;
                        IntPtr pData = new IntPtr();
                        Win32Crypt.CertGetCertificateContextProperty(hCertContext, CSPParam.CERT_SHA1_HASH_PROP_ID, pData, ref uLength);

                        byte[] bData = new byte[20];
                        //GCHandle gch = GCHandle.Alloc(bData, GCHandleType.Pinned);
                        //Marshal.WriteIntPtr(Marshal.UnsafeAddrOfPinnedArrayElement(bData, 0), pData);
                        Marshal.Copy(pData, bData, 0, 20);
                    }
                    else
                    {
                        MessageBox.Show(Win32Crypt.showWin32Error(Marshal.GetLastWin32Error()));

                        return;
                    }
                }
                else
                {
                    MessageBox.Show(Win32Crypt.showWin32Error(Marshal.GetLastWin32Error()));

                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

		private void btn_getContainerList_Click(object sender, EventArgs e)
		{
			
		}

		private void btn_getContainerList_Click_1(object sender, EventArgs e)
		{
			try
			{
				IntPtr hProv = IntPtr.Zero;
				string provider = "HaiTai Cryptographic Service Provider 20485";
				bool bSucc = Win32Crypt.CryptAcquireContext(ref hProv, null, provider, CSPParam.PROV_RSA_FULL, CSPParam.CRYPT_VERIFYCONTEXT);
				if (hProv != IntPtr.Zero)
				{
					StringBuilder sbContainer = null;
					uint containerLength = 0;
					bSucc = Win32Crypt.CryptGetProvParam(hProv, CSPParam.PP_ENUMCONTAINERS, sbContainer, ref containerLength, CSPParam.CRYPT_FIRST);
					sbContainer = new StringBuilder((int)containerLength);
					while (bSucc = Win32Crypt.CryptGetProvParam(hProv, CSPParam.PP_ENUMCONTAINERS, sbContainer, ref containerLength, CSPParam.CRYPT_NEXT))
					{
						//MessageBox.Show(sbContainer.ToString());
						tbox_container.Text += sbContainer.AppendLine().ToString();
					}
				}
				else
				{
					MessageBox.Show("获取CSP句柄失败。");
					Win32Crypt.showWin32Error(Marshal.GetLastWin32Error());
					
				}
				if (hProv != IntPtr.Zero)
				{
					if (!Win32Crypt.CryptReleaseContext(hProv, 0))
					{
						MessageBox.Show("释放CSP句柄失败。");
						Win32Crypt.showWin32Error(Marshal.GetLastWin32Error());
					}
				}
				return;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void btn_signData_Click(object sender, EventArgs e)
		{
			try
			{
				IntPtr hProv = IntPtr.Zero;
				bool bSucc = Win32Crypt.CryptAcquireContext(ref hProv, null, CSPParam.HTCSPNAME, CSPParam.PROV_RSA_FULL, CSPParam.CRYPT_VERIFYCONTEXT);
				if (bSucc)
				{

					IntPtr hUserKey = IntPtr.Zero;
					bSucc = Win32Crypt.CryptGetUserKey(hProv, CSPParam.AT_SIGNATURE, ref hUserKey);
					if (bSucc)
					{
						//导出公钥--------------------------------
						uint pbDataLen = 0;
						bSucc = Win32Crypt.CryptExportKey(hUserKey, IntPtr.Zero, CSPParam.PUBLICKEYBLOB, 0, null, ref pbDataLen);
						if (bSucc)
						{
							byte[] pbPublicKey = new byte[pbDataLen];
							bSucc = Win32Crypt.CryptExportKey(hUserKey, IntPtr.Zero, CSPParam.PUBLICKEYBLOB, 0, pbPublicKey, ref pbDataLen);
							if (bSucc)
							{
								//公钥导出成功
								MessageBox.Show("获取公钥证书成功。");
							}
							else
							{
								MessageBox.Show("获取公钥证书失败。");
								Win32Crypt.showWin32Error(Marshal.GetLastWin32Error());
							}
						}
						else
						{
							MessageBox.Show("获取公钥证书失败。");
							Win32Crypt.showWin32Error(Marshal.GetLastWin32Error());
						}
						//导出公钥--------------------------------
						IntPtr hHash = IntPtr.Zero;
						bSucc = Win32Crypt.CryptCreateHash(hProv, CSPParam.CALG_SHA1, hUserKey, 0, ref hHash);
						if (bSucc)
						{
							byte[] pbData = System.Text.Encoding.UTF8.GetBytes("ChunhuiChen");
							bSucc = Win32Crypt.CryptHashData(hHash, pbData, (uint)pbData.Length, 0);
							if (bSucc)
							{
								//uint uHashSize = 0;
								//bSucc = Win32Crypt.CryptGetHashParam(hHash, CSPParam.HP_HASHSIZE, null, ref uHashSize, 0);
								//if (bSucc)
								//{
								//	uint uHash = 20;
								//	byte[] hashData = new byte[uHash];

								//	bSucc = Win32Crypt.CryptGetHashParam(hHash, CSPParam.HP_HASHVAL, hashData, ref uHash, 0);
								//	if (bSucc)
								//	{

								//		string result = Convert.ToBase64String(hashData);
								//		result = BitConverter.ToString(hashData);
								//		MessageBox.Show(result);
								//	}
								//	else
								//	{
								//		MessageBox.Show("CryptGetHashParam失败。");
								//		MessageBox.Show(Win32Crypt.showWin32Error(Marshal.GetLastWin32Error()));
								//	}
								//}
								//else
								//{
								//}
								pbDataLen = 0;
								bSucc = Win32Crypt.CryptSignHash(hHash, CSPParam.AT_SIGNATURE, null, 0, null, ref pbDataLen);
								if (bSucc)
								{
									byte[] pbSignature = new byte[pbDataLen];
									bSucc = Win32Crypt.CryptSignHash(hHash, CSPParam.AT_SIGNATURE, null, 0, pbSignature, ref pbDataLen);
									if (bSucc)
									{
										//byte[] array = pbSignature.ToArray();
										Array.Reverse(pbSignature);
										//string result = BitConverter.ToString(pbSignature);
										tbox_result.Text = Convert.ToBase64String(pbSignature);
										//tbox_result.Text = result;
										//MessageBox.Show("签名成功");
									}
									else
									{
										MessageBox.Show("签名失败");
									}
								}
								else
								{ 
								}
							}
						}
						else
						{
							MessageBox.Show("获取HASH句柄失败。");
							Win32Crypt.showWin32Error(Marshal.GetLastWin32Error());
						}
						if (hHash != IntPtr.Zero)
						{
							if (!Win32Crypt.CryptDestroyHash(hHash))
							{
								MessageBox.Show("释放HASH句柄失败。");
								Win32Crypt.showWin32Error(Marshal.GetLastWin32Error());
							}
						}

					}
					else
					{
						MessageBox.Show("释放CSP句柄失败。");
						Win32Crypt.showWin32Error(Marshal.GetLastWin32Error());
					}
					if (hUserKey != IntPtr.Zero)
					{
						if (!Win32Crypt.CryptDestroyKey(hUserKey))
						{
							MessageBox.Show("释放加密句柄失败。");
							Win32Crypt.showWin32Error(Marshal.GetLastWin32Error());
						}
					}
				}
				else
				{
					MessageBox.Show("获取CSP句柄失败。");
					Win32Crypt.showWin32Error(Marshal.GetLastWin32Error());
				}
				if (hProv != IntPtr.Zero)
				{
					if (!Win32Crypt.CryptReleaseContext(hProv, 0))
					{
						MessageBox.Show("释放CSP句柄失败。");
						Win32Crypt.showWin32Error(Marshal.GetLastWin32Error());
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void btn_verify_Click(object sender, EventArgs e)
		{
			try
			{
				IntPtr hProv = IntPtr.Zero;
				bool bSucc = Win32Crypt.CryptAcquireContext(ref hProv, null, CSPParam.HTCSPNAME, CSPParam.PROV_RSA_FULL, CSPParam.CRYPT_VERIFYCONTEXT);
				if (bSucc)
				{
					
				}
				else
				{
					MessageBox.Show("获取CSP句柄失败。");
					Win32Crypt.showWin32Error(Marshal.GetLastWin32Error());
				}
				if (hProv != IntPtr.Zero)
				{
					if (!Win32Crypt.CryptReleaseContext(hProv, 0))
					{
						MessageBox.Show("释放CSP句柄失败。");
						Win32Crypt.showWin32Error(Marshal.GetLastWin32Error());
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void btn_exportPublicKey_Click(object sender, EventArgs e)
		{
			try
			{
				IntPtr hProv = IntPtr.Zero;
				bool bSucc = Win32Crypt.CryptAcquireContext(ref hProv, null, CSPParam.HTCSPNAME, CSPParam.PROV_RSA_FULL, CSPParam.CRYPT_VERIFYCONTEXT);
				if (bSucc)
				{

					IntPtr hUserKey = IntPtr.Zero;
					bSucc = Win32Crypt.CryptGetUserKey(hProv, CSPParam.AT_SIGNATURE, ref hUserKey);
					if (bSucc)
					{
						//导出公钥--------------------------------
						uint pbDataLen = 0;
						bSucc = Win32Crypt.CryptExportKey(hUserKey, IntPtr.Zero, CSPParam.PUBLICKEYBLOB, 0, null, ref pbDataLen);
						if (bSucc)
						{
							pbPublicKeyData = new byte[pbDataLen];
							bSucc = Win32Crypt.CryptExportKey(hUserKey, IntPtr.Zero, CSPParam.PUBLICKEYBLOB, 0, pbPublicKeyData, ref pbDataLen);
							if (bSucc)
							{
								//公钥导出成功
								tbox_result.Text = Convert.ToBase64String(pbPublicKeyData);
							}
							else
							{
								MessageBox.Show("获取公钥证书失败。");
								Win32Crypt.showWin32Error(Marshal.GetLastWin32Error());
							}
						}
						else
						{
							MessageBox.Show("获取公钥证书失败。");
							Win32Crypt.showWin32Error(Marshal.GetLastWin32Error());
						}
						//导出公钥--------------------------------

					}
					
					if (hUserKey != IntPtr.Zero)
					{
						if (!Win32Crypt.CryptDestroyKey(hUserKey))
						{
							MessageBox.Show("释放加密句柄失败。");
							Win32Crypt.showWin32Error(Marshal.GetLastWin32Error());
						}
					}
				}
				else
				{
					MessageBox.Show("获取CSP句柄失败。");
					Win32Crypt.showWin32Error(Marshal.GetLastWin32Error());
				}
				if (hProv != IntPtr.Zero)
				{
					if (!Win32Crypt.CryptReleaseContext(hProv, 0))
					{
						MessageBox.Show("释放CSP句柄失败。");
						Win32Crypt.showWin32Error(Marshal.GetLastWin32Error());
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void btn_encrypt_3DES_Click(object sender, EventArgs e)
		{
			string password = "HBCA20160320123456789123";
			byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);
			byte[] src = System.Text.Encoding.UTF8.GetBytes("142415097005983");
			byte[] src1 = new byte[300];
			for (int i = 0; i < src.Length;i++ )
			{
				src1[i] = src[i];
			}
			uint dataLen = (uint)src.Length;
			IntPtr hEnryptKey = IntPtr.Zero;
			try
			{
				IntPtr hProv = IntPtr.Zero;
				//bool bSucc = Win32Crypt.CryptAcquireContext(ref hProv, null, CSPParam.HTCSPNAME, CSPParam.PROV_RSA_FULL, CSPParam.CRYPT_VERIFYCONTEXT);
				bool bSucc = Win32Crypt.CryptAcquireContext(ref hProv, null, null, CSPParam.PROV_RSA_FULL, CSPParam.CRYPT_VERIFYCONTEXT);
				if (bSucc)
				{
					IntPtr hHash = IntPtr.Zero;
					bSucc = Win32Crypt.CryptCreateHash(hProv, CSPParam.CALG_MD5, IntPtr.Zero, 0, ref hHash);
					if (bSucc)
					{
						bSucc = Win32Crypt.CryptHashData(hHash, passwordBytes, (uint)passwordBytes.Length, 0);
						if (bSucc)
						{
							bSucc = Win32Crypt.CryptDeriveKey(hProv, CSPParam.CALG_3DES, hHash, CSPParam.CRYPT_EXPORTABLE, ref hEnryptKey);
							//bSucc = Win32Crypt.CryptGenKey(hProv, CSPParam.CALG_3DES, 0x00A80000|CSPParam.CRYPT_EXPORTABLE, ref hEnryptKey);
							if (bSucc)
							{
								uint keyLenth = 0;
								bSucc = Win32Crypt.CryptExportKey(hEnryptKey, IntPtr.Zero, CSPParam.PLAINTEXTKEYBLOB, 0, null, ref keyLenth);
								byte[] keyData = new byte[keyLenth];
								bSucc = Win32Crypt.CryptExportKey(hEnryptKey, IntPtr.Zero, CSPParam.PLAINTEXTKEYBLOB, 0, keyData, ref keyLenth);
								string keyDataB64 = Convert.ToBase64String(keyData);
								//uint iDataLen = 0;
								//bSucc = Win32Crypt.CryptGetKeyParam(hEnryptKey, CSPParam.KP_PADDING, null, ref iDataLen, 0);
								//byte[] kpiv = new byte[iDataLen];
								//bSucc = Win32Crypt.CryptGetKeyParam(hEnryptKey, CSPParam.KP_PADDING, kpiv, ref iDataLen, 0);
								//bSucc = Win32Crypt.CryptSetKeyParam(hEnryptKey, CSPParam.KP_PADDING, new byte[] { (byte)CSPParam.PKCS5_PADDING }, 0);
								//bSucc = Win32Crypt.CryptGetKeyParam(hEnryptKey, CSPParam.KP_PADDING, kpiv, ref iDataLen, 0);
								//bSucc = Win32Crypt.CryptSetKeyParam(hEnryptKey, CSPParam.KP_IV, new byte[]{0x0d,0x3a,0x62,0xdd,0xfe,0xcb,0x2b,0xba}, 0);
								//bSucc = Win32Crypt.CryptSetKeyParam(hEnryptKey, CSPParam.KP_IV, new byte[] { 50, 51, 52, 53, 54, 55, 56, 57 }, 0);
								bSucc = Win32Crypt.CryptSetKeyParam(hEnryptKey, CSPParam.KP_PADDING,  new byte[]{(byte)CSPParam.PKCS5_PADDING }, 0);
								//bSucc = Win32Crypt.CryptSetKeyParam(hEnryptKey, CSPParam.KP_IV, new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 }, 0);
								bSucc = Win32Crypt.CryptSetKeyParam(hEnryptKey, CSPParam.KP_MODE, new byte[] { (byte)CSPParam.CRYPT_MODE_CBC }, 0);
								Win32Crypt.CryptEncrypt(hEnryptKey, IntPtr.Zero, true, 0, src1, ref dataLen, (uint)300);
								byte[] realData = new byte[dataLen];
								for (int i = 0; i < dataLen; i++)
								{
									realData[i] = src1[i];
								}
								string result = Convert.ToBase64String(realData);
								MessageBox.Show(result);
							}
							else
							{
								MessageBox.Show("CryptDeriveKey失败。");
								Win32Crypt.showWin32Error(Marshal.GetLastWin32Error());
							}
						}
						else
						{
							MessageBox.Show("对秘钥Hash失败。");
							Win32Crypt.showWin32Error(Marshal.GetLastWin32Error());
						}
					}
					else
					{
						MessageBox.Show("获取Hash句柄失败。");
						Win32Crypt.showWin32Error(Marshal.GetLastWin32Error());
					}
					if (hHash != IntPtr.Zero)
					{
						if (!Win32Crypt.CryptDestroyHash(hHash))
						{
							MessageBox.Show("释放CSP句柄失败。");
							Win32Crypt.showWin32Error(Marshal.GetLastWin32Error());
						}
					}
					//bSucc = Win32Crypt.CryptDeriveKey(hProv,CSPParam.CALG_3DES,
				}
				else
				{
					MessageBox.Show("获取CSP句柄失败。");
					Win32Crypt.showWin32Error(Marshal.GetLastWin32Error());
				}
				if (hEnryptKey != IntPtr.Zero)
				{
					if (!Win32Crypt.CryptDestroyKey(hEnryptKey))
					{
						MessageBox.Show("释放CSP句柄失败。");
						Win32Crypt.showWin32Error(Marshal.GetLastWin32Error());
					}
				}

				if (hProv != IntPtr.Zero)
				{
					if (!Win32Crypt.CryptReleaseContext(hProv, 0))
					{
						MessageBox.Show("释放CSP句柄失败。");
						Win32Crypt.showWin32Error(Marshal.GetLastWin32Error());
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

        private void btn_hash_sha1_Click(object sender, EventArgs e)
        {
            string data = "ChunhuiChen";
            byte[] bDatas = System.Text.Encoding.UTF8.GetBytes(data);
            try
            {
                IntPtr hProv = IntPtr.Zero;
				bool bSucc = Win32Crypt.CryptAcquireContext(ref hProv, null, null, CSPParam.PROV_RSA_AES, CSPParam.CRYPT_VERIFYCONTEXT);
                if (bSucc)
                {
                    IntPtr hHash = IntPtr.Zero;
					bSucc = Win32Crypt.CryptCreateHash(hProv, CSPParam.CALG_SHA256, IntPtr.Zero, 0, ref hHash);
                    if (bSucc)
                    {
                        bSucc = Win32Crypt.CryptHashData(hHash, bDatas, (uint)bDatas.Length, 0);
                        if (bSucc)
                        {
							uint uHashSize = 0;
							uint uHash = 20;
							bSucc = Win32Crypt.CryptGetHashParam(hHash, CSPParam.HP_HASHSIZE, null, ref uHashSize, 0);
							if (bSucc)
							{
								byte[] hashData = new byte[uHash];
								bSucc = Win32Crypt.CryptGetHashParam(hHash, CSPParam.HP_HASHVAL, hashData, ref uHash, 0);
								if (bSucc)
								{
									
									string result = Convert.ToBase64String(hashData);
									result = BitConverter.ToString(hashData);
									MessageBox.Show(result);
								}
								else
								{
									MessageBox.Show("CryptGetHashParam失败。");
									MessageBox.Show(Win32Crypt.showWin32Error(Marshal.GetLastWin32Error()));
								}
							}
							else
							{
								MessageBox.Show("CryptGetHashParam失败。");
								Win32Crypt.showWin32Error(Marshal.GetLastWin32Error());
							}
                        }
                        else
                        {
							MessageBox.Show("CryptHashData失败。");
                            Win32Crypt.showWin32Error(Marshal.GetLastWin32Error());
                        }
                    }
                    else
                    {
                        MessageBox.Show("获取HASH句柄失败。");
                        Win32Crypt.showWin32Error(Marshal.GetLastWin32Error());
                    }
                    if (hHash != IntPtr.Zero)
                    {
						if (!Win32Crypt.CryptDestroyHash(hHash))
                        {
                            MessageBox.Show("释放HASH句柄失败。");
                            Win32Crypt.showWin32Error(Marshal.GetLastWin32Error());
                        }
                    }
                }
                else
                {
                    MessageBox.Show("获取CSP句柄失败。");
                    Win32Crypt.showWin32Error(Marshal.GetLastWin32Error());
                }
                if (hProv != IntPtr.Zero)
                {
                    if (!Win32Crypt.CryptReleaseContext(hProv, 0))
                    {
                        MessageBox.Show("释放CSP句柄失败。");
                        Win32Crypt.showWin32Error(Marshal.GetLastWin32Error());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
