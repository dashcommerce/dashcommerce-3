The following folks were nice enough to allow us to use some of their code (or customized versions) for this project:

Steve Stchur (http://aspnet.4guysfromrolla.com/articles/021605-1.aspx) - Provided the mechanism for the DataGrid row highlighting. I've customized it, but the idea was his.

Michael Libby (http://aspalliance.com/822) - Provided the mechanism for binding some the menus. I've customized it, but the idea came from that article.

Also, thanks to many of the community members who have contributed to the project!

----------------------------------------------------------------------------------
In order to run the dashCommerce 3.3 Download, you will need Visual Studio 2008.

Open the .sln file and build the solution. Once you have built the solution, create a virtual directory in IIS and have it's root pointing at the Web folder.

You can then run the installer, located at http://<yourdomain>/install/install.aspx. This installer will run you through the process of installing the database and the necessary database objects.

If you have any questions, comments, or concern, please leave them in the dashCommerce 3.0 forum at www.dashCommerce.org.

For a current list of the technologies needed to run dashCommerce, please checkout the Technology topic under Learn More at www.dashCommerce.org.
-----------------------------------------------------------------------------------
In order to run dashCommerce, you will need the following installed on your server / computer:

Windows XP Pro or Higher
Internet Information Service (IIS)
Microsoft .NET Framework 3.5 (http://www.microsoft.com/downloads/details.aspx?familyid=333325FD-AE52-4E35-B531-508D977D32A6&displaylang=en)
SQL Server 2005 Express Edition (http://www.microsoft.com/express/sql/default.aspx)
ASP.NET AJAX Extensions 3.0 (http://www.asp.net/ajax/downloads/)

If you are going to develop with dashCommerce, then you will also need the following installed on your development machine as well:

Microsoft Visual Studio 2008 Professional (with Service Packs) (http://msdn2.microsoft.com/en-us/vstudio/default.aspx)
ASP.NET WebProfile Generator (http://www.codeplex.com/WebProfile)
SubSonic 2.0.3 (http://subsonicproject.com/)

You need to give the NETWORK SERVICE account "READ" and "WRITE" permissions on the 'repository' directory (ASP.NET account for XP).