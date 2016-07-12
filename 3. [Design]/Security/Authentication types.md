Authentication types
---

 A web client can authenticate a user to a web server using one of the following mechanisms:

  -  HTTP Basic Authentication

  -  HTTP Digest Authentication

  -  HTTPS Client Authentication

  - Form Based Authentication 
  
**HTTP Basic Authentication**

---

HTTP Basic Authentication, which is based on a username and password, is the authentication mechanism defined in the HTTP/1.0 specification. A web server requests a web client to authenticate the user. As part of the request, the web server passes the realm (a string) in which the user is to be authenticated. The realm string of Basic Authentication does not have to reflect any particular security policy domain (confusingly also referred to as a realm). The web client obtains the username and the password from the user and transmits them to the web server. The web server then authenticates the user in the specified realm.

Basic Authentication is not a secure authentication protocol. User passwords are sent in simple base64 ENCODING (not ENCRYPTED !), and the target server is not authenticated. Additional protection can alleviate some of these concerns: a secure transport mechanism (HTTPS), or security at the network level (such as the IPSEC protocol or VPN strategies) is applied in some deployment scenarios. 


**HTTP Digest Authentication**

---

Like HTTP Basic Authentication, HTTP Digest Authentication authenticates a user based on a username and a password. However the authentication is performed by transmitting the password in an ENCRYPTED form which is much MORE SECURE than the simple base64 encoding used by Basic Authentication, e.g. HTTPS Client Authentication. As Digest Authentication is not currently in widespread use, servlet containers are encouraged but NOT REQUIRED to support it.

The advantage of this method is that the cleartext password is protected in transmission, it cannot be determined from the digest that is submitted by the client to the server.

Digested password authentication supports the concept of digesting user passwords. This causes the stored version of the passwords to be encoded in a form that is not easily reversible, but that the Web server can still utilize for authentication. From a user perspective, digest authentication acts almost identically to basic authentication in that it triggers a login dialog. The difference between basic and digest authentication is that on the network connection between the browser and the server, the password is encrypted, even on a non-SSL connection. In the server, the password can be stored in clear text or encrypted text, which is true for all login methods and is independent of the choice that the application deployer makes. 

**HTTPS Client Authentication**

---

End user authentication using HTTPS (HTTP over SSL) is a strong authentication mechanism. This mechanism requires the user to possess a Public Key Certificate (PKC).

Client-certificate authentication is a more secure method of authentication than either BASIC or FORM authentication. It uses HTTP over SSL, in which the server and, optionally, the client authenticate one another with Public Key Certificates. Secure Sockets Layer (SSL) provides data encryption, server authentication, message integrity, and optional client authentication for a TCP/IP connection. You can think of a public key certificate as the digital equivalent of a passport. It is issued by a trusted organization, which is called a certificate authority (CA), and provides identification for the bearer. If you specify client-certificate authentication, the Web server will authenticate the client using the client's X.509 certificate, a public key certificate that conforms to a standard that is defined by X.509 Public Key Infrastructure (PKI). Prior to running an application that uses SSL, you must configure SSL support on the server and set up the public key certificate. 

**Form Based Authentication**

---

The look and feel of the 'login screen' cannot be varied using the web browser's built-in authentication mechanisms. This specification introduces a required form based authentication mechanism which allows a Developer to CONTROL the LOOK and FEEL of the login screens.

The web application deployment descriptor contains entries for a login form and error page. The login form must contain fields for entering a username and a password. These fields must be named j_username and j_password, respectively. 
When a user attempts to access a protected web resource, the container checks the user's authentication. If the user is authenticated and possesses authority to access the resource, the requested web resource is activated and a reference to it is returned. If the user is not authenticated, all of the following steps occur: 

 - The login form associated with the security constraint is sent to the client and the URL path triggering the authentication is stored by the container. 
 - The user is asked to fill out the form, including the username and password fields. 
 - The client posts the form back to the server. 
 - The container attempts to authenticate the user using the information from the form. 
 - If authentication fails, the error page is returned using either a forward or a redirect, and the status code of the response is set to 200. 
 - If authentication succeeds, the authenticated user's principal is checked to see if it is in an authorized role for accessing the resource. 
 - If the user is authorized, the client is redirected to the resource using the stored URL path. 
 

**Cookies**

---

When a server receives an HTTP request in the response, it can send a Set-Cookie header. The browser puts it into a cookie jar, and the cookie will be sent along with every request made to the same origin in the Cookie HTTP header.

To use cookies for authentication purposes, there are a few key principles that one must follow.

**Always use HttpOnly cookies**

To mitigate the possibility of XSS attacks always use the HttpOnly flag when setting cookies. This way they won't show up in document.cookies

**Always use signed cookies**

With signed cookies, a server can tell if a cookie was modified by the client.

**Tokens**

Nowadays JWT (JSON Web Token) is everywhere - still it is worth taking a look on potential security issues.

JWT consists of three parts: 

 - Header, containing the type of the token and the hashing algorithm
 - Payload, containing the claims
 - Signature, which can be calculated as follows if you chose HMAC SHA256: HMACSHA256( base64UrlEncode(header) + "." + base64UrlEncode(payload), secret)
 
 


