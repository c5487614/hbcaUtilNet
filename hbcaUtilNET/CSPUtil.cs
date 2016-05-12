using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Runtime.InteropServices;
using System.ComponentModel;
namespace hbcaUtilNET
{
    
    class Win32Crypt
    {
        /*
         BOOL WINAPI CryptEnumProviders(
            _In_    DWORD  dwIndex,
            _In_    DWORD  *pdwReserved,
            _In_    DWORD  dwFlags,
            _Out_   DWORD  *pdwProvType,
            _Out_   LPTSTR pszProvName,
            _Inout_ DWORD  *pcbProvName
         );
         */
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool CryptEnumProviders(
            uint dwIndex,
            uint dwParam,
            uint dwFlag,
            ref uint pdwProvType,
            StringBuilder pszProvName,
            ref uint pcbProvName
            );

        /*
         BOOL WINAPI CryptAcquireContext(
            _Out_ HCRYPTPROV *phProv,
            _In_  LPCTSTR    pszContainer,
            _In_  LPCTSTR    pszProvider,
            _In_  DWORD      dwProvType,
            _In_  DWORD      dwFlags
         );
         */
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool CryptAcquireContext(
            ref IntPtr hProv,
            string pszContainer,
            string pszProvider,
            uint dwProvType,
            uint dwFlags
            );
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool CryptReleaseContext(
            IntPtr hProv,
            uint dwFlags);

        public static string showWin32Error(int errorcode)
        {
            Win32Exception myEx = new Win32Exception(errorcode);
            StringBuilder sbError = new StringBuilder();
            sbError.AppendLine(string.Format("Error code:\t 0x{0:X}", myEx.ErrorCode));
            sbError.AppendLine(string.Format("Error message:\t " + myEx.Message));
            Console.WriteLine("Error code:\t 0x{0:X}", myEx.ErrorCode);
            Console.WriteLine("Error message:\t " + myEx.Message);
            return sbError.ToString();
        }

        /*BOOL WINAPI CryptGetProvParam(
        HCRYPTPROV hProv,
        DWORD dwParam,
        BYTE* pbData,
        DWORD* pdwDataLen,
        DWORD dwFlags
        );
        */
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool CryptGetProvParam(
            IntPtr hProv,
            uint dwParam,
            [In,Out] byte[] pbData,
            ref uint dwDataLen,
            uint dwFlags);
        /*
        BOOL WINAPI CryptGetProvParam(
        HCRYPTPROV hProv,
        DWORD dwParam,
        BYTE* pbData,
        DWORD* pdwDataLen,
        DWORD dwFlags
        );
        */
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool CryptGetProvParam(
            IntPtr hProv,
            uint dwParam,
            [MarshalAs(UnmanagedType.LPStr)] StringBuilder pbData,
            ref uint dwDataLen,
            uint dwFlags);
        /*
        BOOL WINAPI CryptCreateHash(
        _In_  HCRYPTPROV hProv,
        _In_  ALG_ID     Algid,
        _In_  HCRYPTKEY  hKey,
        _In_  DWORD      dwFlags,
        _Out_ HCRYPTHASH *phHash
        );
         */
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool CryptCreateHash(
            IntPtr hProv,
            uint AlgId,
            IntPtr hKey,
            uint dwFlags,
            ref IntPtr hHash);
        /*
        BOOL WINAPI CryptGetUserKey(
        _In_  HCRYPTPROV hProv,
        _In_  DWORD      dwKeySpec,
        _Out_ HCRYPTKEY  *phUserKey
        );
         */
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool CryptGetUserKey(
            IntPtr hProv,
            uint dwKeySpec,
            ref IntPtr hUserKey
            );
        /*
        BOOL WINAPI CryptGetKeyParam(
        _In_    HCRYPTKEY hKey,
        _In_    DWORD     dwParam,
        _Out_   BYTE      *pbData,
        _Inout_ DWORD     *pdwDataLen,
        _In_    DWORD     dwFlags
        );  
        */
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool CryptGetKeyParam(
            IntPtr hUserKey,
            uint dwParam,
            [In, Out] byte[] pbData,
            ref uint dwDataLen,
            uint dwFlags
            );
        /*
        const void* WINAPI CertCreateContext(
        _In_           DWORD                     dwContextType,
        _In_           DWORD                     dwEncodingType,
        _In_     const BYTE                      *pbEncoded,
        _In_           DWORD                     cbEncoded,
        _In_           DWORD                     dwFlags,
        _In_opt_       PCERT_CREATE_CONTEXT_PARA pCreatePara
        );
         */
        [DllImport("Crypt32.dll", SetLastError = true)]
        public static extern IntPtr CertCreateContext(
           uint dwContextType,
           uint dwEncodingType,
           byte[] pbData,
           uint cbEncoded,
           uint dwFlags,
           [In, Optional] uint pCreatePara
           );
        /*
        PCCERT_CONTEXT WINAPI CertCreateCertificateContext(
        _In_       DWORD dwCertEncodingType,
        _In_ const BYTE  *pbCertEncoded,
        _In_       DWORD cbCertEncoded
        );
         */
        [DllImport("Crypt32.dll", SetLastError = true)]
        public static extern IntPtr CertCreateCertificateContext(
            uint dwCertEncodingType,
            byte[] pbCertEncoded,
            uint cbEncoded);
        /*
        BOOL WINAPI CertGetCertificateContextProperty(
        _In_    PCCERT_CONTEXT pCertContext,
        _In_    DWORD          dwPropId,
        _Out_   void           *pvData,
        _Inout_ DWORD          *pcbData
        );
         */
        [DllImport("Crypt32.dll", SetLastError = true)]
        public static extern bool CertGetCertificateContextProperty(
            IntPtr hCertContext,
            uint dwPropId,
            [MarshalAs(UnmanagedType.LPStr)] StringBuilder pbData,
            ref uint dataLength
            );
        [DllImport("Crypt32.dll", SetLastError = true)]
        public static extern bool CertGetCertificateContextProperty(
            [In] IntPtr pCertContext, 
            [In] uint dwPropId, [In, Out] 
            IntPtr pvData, 
            [In, Out] ref uint pcbData);
        /*
        DWORD WINAPI CertGetNameString(
        _In_  PCCERT_CONTEXT pCertContext,
        _In_  DWORD          dwType,
        _In_  DWORD          dwFlags,
        _In_  void           *pvTypePara,
        _Out_ LPTSTR         pszNameString,
        _In_  DWORD          cchNameString
        );
         */
        [DllImport("Crypt32.dll", SetLastError = true)]
        public static extern bool CertGetNameString(
            IntPtr hCertContext,
            uint dwType,
            uint dwFlags,
            ref uint pvTypePara,
            [MarshalAs(UnmanagedType.LPStr)] StringBuilder pbData,
            ref uint cchNameString
            );
        [DllImport("Crypt32.dll", SetLastError = true)]
        public static extern bool CertGetNameString(
            IntPtr hCertContext,
            uint dwType,
            uint dwFlags,
            [MarshalAs(UnmanagedType.LPStr)] StringBuilder oIdName,
            [MarshalAs(UnmanagedType.LPStr)] StringBuilder pbData,
            ref uint cchNameString
            );
        /*
        BOOL WINAPI CertStrToName(
        _In_      DWORD   dwCertEncodingType,
        _In_      LPCTSTR pszX500,
        _In_      DWORD   dwStrType,
        _In_opt_  void    *pvReserved,
        _Out_     BYTE    *pbEncoded,
        _Inout_   DWORD   *pcbEncoded,
        _Out_opt_ LPCTSTR *ppszError
        );
         [DllImport("Crypt32.dll", SetLastError = true)]
        public static extern bool CertStrToName(
            uint dwCertEncodingType,
            );
         */

        /*
        DWORD WINAPI CertNameToStr(
        _In_  DWORD           dwCertEncodingType,
        _In_  PCERT_NAME_BLOB pName,
        _In_  DWORD           dwStrType,
        _Out_ LPTSTR          psz,
        _In_  DWORD           csz
        );*/    
        [DllImport("crypt32.dll", CharSet=CharSet.Auto, SetLastError=true)]
        public static extern uint CertNameToStr(
            [In] uint dwCertEncodingType, 
            [In] IntPtr pName, 
            [In] uint dwStrType, 
            [In, Out] IntPtr psz, 
            [In] uint csz);
		/*
		BOOL WINAPI CryptDestroyKey(
		  _In_ HCRYPTKEY hKey
		);*/
		[DllImport("Advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern bool CryptDestroyKey(
			[In] IntPtr hUserKey
			);
		/*
		BOOL WINAPI CryptDestroyKey(
		  _In_ HCRYPTKEY hKey
		);*/
		[DllImport("Advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern bool CryptDestroyHash(
			[In] IntPtr hHash
			);
		/*
		BOOL WINAPI CryptHashData(
		  _In_ HCRYPTHASH hHash,
		  _In_ BYTE       *pbData,
		  _In_ DWORD      dwDataLen,
		  _In_ DWORD      dwFlags
		);
		*/
		[DllImport("Advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern bool CryptHashData(
			[In] IntPtr hHash,
			[In] byte[] pbData,
			[In] uint dwDataLen,
			[In] uint dwFlags
			);
		/*
		BOOL WINAPI CryptGetHashParam(
		  _In_    HCRYPTHASH hHash,
		  _In_    DWORD      dwParam,
		  _Out_   BYTE       *pbData,
		  _Inout_ DWORD      *pdwDataLen,
		  _In_    DWORD      dwFlags
		);
		 */
		[DllImport("Advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern bool CryptGetHashParam(
			[In] IntPtr hHash,
			[In] uint dwParam,
			[Out] byte[] pbData,
			[In,Out] ref uint dwDataLen,
			[In] uint dwFlags
			);
		/*
		BOOL WINAPI CryptSignHash(
		  _In_    HCRYPTHASH hHash,
		  _In_    DWORD      dwKeySpec,
		  _In_    LPCTSTR    sDescription,
		  _In_    DWORD      dwFlags,
		  _Out_   BYTE       *pbSignature,
		  _Inout_ DWORD      *pdwSigLen
		);*/
		[DllImport("Advapi32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern bool CryptSignHash(
			[In] IntPtr hHash,
			[In] uint dwKeySpec,
			[In] string sDescription,
			[In] uint dwFlags,
			[Out] byte[] pbSignature,
			[In, Out] ref uint pbDataLen
			);
		/*
		 * BOOL WINAPI CryptExportKey(
			  _In_    HCRYPTKEY hKey,
			  _In_    HCRYPTKEY hExpKey,
			  _In_    DWORD     dwBlobType,
			  _In_    DWORD     dwFlags,
			  _Out_   BYTE      *pbData,
			  _Inout_ DWORD     *pdwDataLen
			);
		 * */
		[DllImport("Advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern bool CryptExportKey(
			[In] IntPtr hKey,
			[In] IntPtr hExpKey,
			[In] uint dwBlobType,
			[In] uint dwFlags,
			[Out] byte[] pbData,
			[In,Out] ref uint pdwDataLen
			);
		/*
		BOOL WINAPI CryptEncrypt(
		  _In_    HCRYPTKEY  hKey,
		  _In_    HCRYPTHASH hHash,
		  _In_    BOOL       Final,
		  _In_    DWORD      dwFlags,
		  _Inout_ BYTE       *pbData,
		  _Inout_ DWORD      *pdwDataLen,
		  _In_    DWORD      dwBufLen
		);
		 * */
		[DllImport("Advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern bool CryptEncrypt(
			[In] IntPtr hKey,
			[In] IntPtr hHash,
			[In] bool final,
			[In] uint dwFlags,
			[Out] byte[] pbData,
			[In,Out] ref uint pbDataLen,
			[In] uint dwBufLen
			);
		/*
		BOOL WINAPI CryptGenKey(
		  _In_  HCRYPTPROV hProv,
		  _In_  ALG_ID     Algid,
		  _In_  DWORD      dwFlags,
		  _Out_ HCRYPTKEY  *phKey
		);
		 * */
		[DllImport("Advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern bool CryptGenKey(
			[In] IntPtr hProv,
			[In] uint Algid,
			[In] uint dwFlags,
			[In,Out] ref IntPtr hKey
			);
		/*
		BOOL WINAPI CryptDeriveKey(
		  _In_    HCRYPTPROV hProv,
		  _In_    ALG_ID     Algid,
		  _In_    HCRYPTHASH hBaseData,
		  _In_    DWORD      dwFlags,
		  _Inout_ HCRYPTKEY  *phKey
		);
		 * */
		[DllImport("Advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern bool CryptDeriveKey(
			[In] IntPtr hProv,
			[In] uint Algid,
			[In] IntPtr hBaseData,
			[In] uint dwFlags,
			[In,Out] ref IntPtr hKey
			);
		/*
		BOOL WINAPI CryptSetKeyParam(
		  _In_       HCRYPTKEY hKey,
		  _In_       DWORD     dwParam,
		  _In_ const BYTE      *pbData,
		  _In_       DWORD     dwFlags
		);
		 * */
		[DllImport("Advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern bool CryptSetKeyParam(
			[In] IntPtr hKey,
			[In] uint dwParam,
			[In] byte[] pbData,
			[In] uint dwFlags
			);
		/*
		BOOL WINAPI CryptGetKeyParam(
		  _In_    HCRYPTKEY hKey,
		  _In_    DWORD     dwParam,
		  _Out_   BYTE      *pbData,
		  _Inout_ DWORD     *pdwDataLen,
		  _In_    DWORD     dwFlags
		);[DllImport("Advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern bool CryptGetKeyParam(
			[In] IntPtr hKey,
			[In] uint dwParam,
			[Out] byte[] pbData,
			[In, Out] ref uint pdwDataLen,
			[In] uint dwFlags
			);
		 * */

		public static List<string> getAllProviders()
        {
            uint dwIndex = 0;
            uint dwType = 0,dwProvLength = 0;
            StringBuilder sbName = null;
            List<string> listProvs = new List<string>();

            
            while (Win32Crypt.CryptEnumProviders(dwIndex,0,0,ref dwType,null,ref dwProvLength)) 
            {
                sbName = new StringBuilder((int)dwProvLength);
                Win32Crypt.CryptEnumProviders(dwIndex, 0, 0, ref dwType, sbName, ref dwProvLength);
                if (sbName.Length > 0)
                {
                    listProvs.Add(sbName.ToString());
                }
                dwIndex++;
            }
            return listProvs;
        }
    }
    public class CSPParam
    {
        public const string HTCSPNAME = "HaiTai Cryptographic Service Provider 20485";
		public const string MSCSPNAME = "Microsoft Base Cryptographic Provider";
        //ALL CSP PROVIDER
        public const uint PROV_RSA_FULL = 0x00000001;
		public const uint PROV_RSA_AES = 24;
        //NO PRIVATE KEY ACCESS REQUIRED
        public const uint CRYPT_VERIFYCONTEXT = 0xF0000000;

        public const uint AlogId = 0x00008004;

        public const uint AT_SIGNATURE = 0x00000002;

        public const uint KP_CERTIFICATE = 26;

        public const uint CERT_NAME_RDN_TYPE = 2;

        public const uint X509_ASN_ENCODING = 0x00000001;
        public const uint PKCS_7_ASN_ENCODING = 0x00010000;

        public const uint MY_CERT_ENCODING = X509_ASN_ENCODING | PKCS_7_ASN_ENCODING;

        public const uint CERT_NAME_ISSUER_FLAG = 1;

        public const uint CRYPT_DELETEKEYSET = 16;

        public const uint CRYPT_NEWKEYSET = 8;

        //证书HASH指纹
        public const uint CERT_SHA1_HASH_PROP_ID = 3;
		//枚举容器
		public const uint PP_CONTAINER = 6;
		//枚举容器
		public const uint PP_ENUMCONTAINERS = 2;
		//第一个
		public const uint CRYPT_FIRST = 1;
		//下一个
		public const uint CRYPT_NEXT = 2;

		//SHA1 算法
		public const uint CALG_SHA1 = 0x00008004;

		//SHA256 算法
		public const uint CALG_SHA256 = 0x0000800c;

		public const uint ALG_CLASS_HASH = 32768;
		public const uint ALG_TYPE_ANY = 0;
		public const uint ALG_SID_SHA = 4;
		public const uint CALG_SHA1TEST = (ALG_CLASS_HASH | ALG_TYPE_ANY | ALG_SID_SHA);
		//公钥
		public const uint PUBLICKEYBLOB = 6;
		
		public const uint ALG_TYPE_BLOCK = 1536;
		public const uint ALG_CLASS_DATA_ENCRYPT = 24576;

		//3des
		//public const uint CALG_3DES = 0x00006603;
		public const uint CALG_3DES = (ALG_CLASS_DATA_ENCRYPT | ALG_TYPE_BLOCK | 3);
		//MD5
		public const uint CALG_MD5 = 0x00008003;
		//秘钥可被导出
		public const uint CRYPT_EXPORTABLE = 1;
		//
		public const uint KP_MODE = 0x00000004;
		//3DES CBC
		public const byte CRYPT_MODE_CBC = 1;
		//
		public const uint KP_IV = 0x00000001;
		//KP-PADDING
		public const uint KP_PADDING = 0x00000003;
		//PKCS5-PADDING
		public const uint PKCS5_PADDING = 1;
		//
		public const uint CRYPT_MODE_ECB = 2;
		//PLAINTEXTKEYBLOB
		public const uint PLAINTEXTKEYBLOB = 8;

		//HASH SIZE
		public const uint HP_HASHSIZE = 4;
		//HASH VALUE
		public const uint HP_HASHVAL = 2;
		public const uint CRYPT_NOHASHOID = 0x00000001;

    }
}
