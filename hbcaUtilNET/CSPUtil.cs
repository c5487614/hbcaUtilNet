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
}
