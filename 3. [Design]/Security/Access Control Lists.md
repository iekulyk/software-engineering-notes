[Writing Secure Code]

Access Control Lists.
---

Microsoft Windows offers many means to limit who has access to what. The most common, and to some extent one of the least understood, means is the access control list (ACL). The ACL is a fundamental part of Microsoft Windows

ACLs are quite literally your application's last backstop against an attack, with the possible exception of good encryption and key management. If an attacker can access a resource, his job is done. 

Good ACLs are an incredibly important defensive mechanism. Use them.

Imagine you have some data held in the registry and the ACL on the registry key is Everyone (Full Control), which means anyone can do anything to the data, including read, write, or change the data or deny others access to the data.
```
#define MAX_BUFF (64)
#define MY_VALUE "SomeData"

BYTE bBuff[MAX_BUFF];
ZeroMemory(bBuff, MAX_BUFF);

//Open the registry.
HKEY hKey = NULL;
if (RegOpenKeyEx(HKEY_LOCAL_MACHINE,
                 "Software\\Northwindtraders",
                 0,
                 KEY_READ,
                 &hKey) == ERROR_SUCCESS) {
                 
      //Determine how much data to read.
      DWORD cbBuff = 0;
      if (RegQueryValueEx(hKey,
                          MY_VALUE,
                          NULL,
                          NULL,
                          NULL,
                          &cbBuff) == ERROR_SUCCESS) {
          //Now read all the data.
          if (RegQueryValueEx(hKey,
                              MY_VALUE,
                              NULL,
                              NULL,
                              bBuff,
                              &cbBuff) == ERROR_SUCCESS) {
              //Cool!
              //We have read the data from the registry.
          }
      }
}
if (hKey) 
    RegCloseKey(hKey); 
```

A potential buffer overrun exists if this value is greater than 64 bytes. 

How dangerous is this? First the code is bad and should be fixed. (I'll show you a fix in a moment.) The ACL on the registry key determines the threat potential. If the ACL is Everyone (Full Control), the threat is great because any user can set a buffer greater than 64 bytes on the registry key. Also, the attacker can set the ACL to Everyone (Deny Full Control), which will deny your application access to the data. 

If the ACL is Administrators (Full Control) and Everyone (Read), the threat is less severe because only an administrator can set data on the key and change the ACL. Administrators have Full Control, which includes the ability to write an ACL, also called WRITE_DAC. All other users can only read the data. In other words, to force the sample application to fail, you need to be an administrator on the computer. If an attacker is already an administrator on the computer, this is only the start of your problems!

**An ACL is an access control method employed by many operating systems to determine to what degree an account is allowed to access a resource**

Windows NT and later contain two types of ACLs: discretionary access control lists (DACLs) and system access control list (SACLs). A DACL determines access rights to secured resources. A SACL determines audit policy for secured resources.

  - Examples of resources that can be secured using DACLs and audited using SACLs include the following: 
    - Files and directories
    - File shares (for example, \\BlakesLaptop\BabyPictures)
    - Registry keys
    - Shared memory
    - Job objects
    - Mutexes
    - Named pipes
    - Printers
    - Semaphores
    - Active directory objects

Each DACL includes zero or more access control entries (ACEs), which I'll define in a moment. A NULL DACL—that is, a current DACL that is set to NULL— means no access control mechanism exists on the resource. NULL DACLs are bad and should never be used because an attacker can set any access policy on the object. I'll cover NULL DACLs later in this chapter.

An ACE includes two major components: an account represented by the account's Security ID (SID) and a description of what that SID can do to the resource in question. As you might know, a SID represents a user, group, or computer. The most famous—some would say infamous—ACE is Everyone (Full Control). Everyone is the account; the SID for Everyone, also called World, is S-1-1-0. Full Control is the degree to which the account can access the resource in question—in this case, the account can do anything to the resource. Believe me, Full Control really does mean anything! Note that an ACE can also be a deny ACE, an ACE that disallows certain access. For example, Everyone (Deny Full Control) means that every account—including you!—will be denied access to the resource. If an attacker can set this ACE on a resource, serious denial of service (DoS) threats exist because no one can access the resource.

NOTE
The object owner can always get access to the resource, even if the ACL denies him access. All securable objects in Windows have an owner. If you create an object, such as a file, you are the owner. The only exception is an object created by an administrator, in which case all administrators are owners of that object.


**A Method of Choosing Good ACLs**

Over the past few months I've come to live by the following security maxim when performing security reviews: “You must account for every ACE in an ACL.” In fact, if you can't determine why an ACE exists in an ACL, you should remove the ACE from the ACL. As with all engineering processes, you should design your system using a high-level analysis technique to model the business requirements before creating the solution, and the same philosophy applies to creating ACLs. I've seen many applications that have ACLs “designed” in an utterly ad hoc manner, and this has led to security vulnerabilities or poor user experiences.

 - The process of defining an appropriate ACL for your resources is simple:
 - Determine the resources you use.
 - Determine the business-defined access requirements.
 - Determine the appropriate access control technology.
 - Convert the access requirements to access control technology.

First and foremost, you need to determine which resources you use—for example, files, registry keys, database data, Web pages, named pipes, and so on—and which resources you want to protect. Once you know this, you'll have a better understanding of the correct ACLs to apply to protect the resources. If you can't determine what your resources are, ask yourself where the data comes from—that should lead you to the resource.

Next you should determine the access requirements for the resources. Recently I had a meeting with a group that used Everyone (Full Control) on some critical files they owned. The rationale was that local users on the computer needed to access the files. After I probed the team a little more, a team member said the following

```All users at the computer can read the data files. Administrators need to perform all tasks on the files. However, users in accounting should have no access to the files.```

 For those of you who have used Unified Modeling Language (UML) use cases, you can see what I'm doing—extracting key parts of speech from the scenario to build business requirements. From these business requirements, you can derive technical solutions—in this case, access requirements used to derive access control lists.

Remember that ACLs are composed of ACEs and that an ACE is a rule in the following form: “A subject can perform an action against an object” or “Someone can perform something on some resource.” In our example, we have three ACEs. All users at the computer can read the data files is a rule that translates nicely into the first ACE on the data files: Interactive Users (Read). It's classic noun-verb-noun. The nouns are your subjects and objects, and the verb determines what the ACE access mask should be. The access mask is a 32-bit value that defines the rights that are allowed or denied in an ACE.

Interactive Users is the same as All users at the computer. Also, users who are accessing the computer via FTP or HTTP and are authenticated using Basic authentication are logged on interactively by default when using Internet Information Services 

You should follow this process for all subjects (users, groups, and computers) until you create a complete ACL. 

When building ACLs using code, you should always place deny ACEs at the start of the ACL. ACLs built using the Windows ACL user interface will do this for you. Failure to place deny ACEs before allow ACEs might grant access that should not be allowed.

**Effective Deny ACEs**

---

Sometimes, when defining the access policy for resources, you'll decide that some users should have no access to a resource. In that case, don't be afraid to use a deny ACE.

Determining access control requirements is as simple as writing out the access control rules—again, based on the business rules—for the application and then looking for verbs and nouns in the requirements. Then you can determine which access control technologies are appropriate and how to configure the mechanisms to comply with the access control policy.

