# ICU
quick 'n dirty poc based on PoC windows auth prompt in c# based on https://gist.githubusercontent.com/mayuki/339952/raw/2c36b735bc51861a37194971a5e944f22c94df7c/CredentialUI.cs

inspiration comes from https://ired.team/offensive-security/credential-access-and-credential-dumping/credentials-collection-via-creduipromptforcredentials

Will continue to bug the user to input credentials until they are valid, or until they press cancel. 
written in c#, so could potentially be used by execute-assembly.
