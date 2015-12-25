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
                //const uint CRYPT_FIRST = 0x00000001;
                //const uint PP_ENUMCONTAINERS   = 0x00000002;
                //const uint PP_SIGNATURE_PIN = 0x00000021;
                //const uint PP_ADMIN_PIN = 0x0000001F;
                //const uint PP_CONTAINER = 0x00000006;
                //const int BUFFERSIZE = 256;
                //uint enumFlags = PP_ENUMCONTAINERS;
                ////enumFlags = PP_SIGNATURE_PIN;
                //StringBuilder sb = new StringBuilder(BUFFERSIZE);
                //uint pcbData = BUFFERSIZE;
                //uint dwFlags = 0;
                //dwFlags = CRYPT_FIRST;
                ////enumFlags = PP_CONTAINER;
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
                const uint CERT_NAME_ISSUER_FLAG = 0;
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
                        Win32Crypt.CertGetNameString(hCertContext, CERT_NAME_RDN_TYPE, CERT_NAME_ISSUER_FLAG, ref pvTypePara, sbData, ref dataLength);
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
    }
}
