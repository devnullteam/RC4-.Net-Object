
# RC4 .Net Object

Objeto .Net que permite cifrar y descifrar datos binarios con el algoritmo RC4.

-----------------

> **Atención!**

> No se recomienda el uso de RC4 para proyectos modernos y con aspiraciones de ser seguras/privadas, puedes encontrar más información [aquí](https://en.wikipedia.org/wiki/RC4).

Este objeto está basado en la publicación de [Joke758](http://codes-sources.commentcamarche.net/source/41581-rc4-encrypt-decrypt-fonction) y es compatible con el algoritmo estándar de RC4, probado con algoritmos de otros lenguajes. Tiene ligeras modificaciones en las rutinas principales de cifrado/descifrado para trabajar con arreglos de bytes en vez de cadenas de texto, lo que implicitamente gana en velocidad y versatilidad.

Un ejemplo de uso en Powershell:

	> [System.Reflection.Assembly]::LoadFile("C:\Absolute\Path\RC4mod.dll")
	> $RC4 | Get-Member
	TypeName: team.devnull.ciphers.RC4
	Name        MemberType Definition
	----        ---------- ----------
	Decrypt     Method     void Decrypt()
	Encrypt     Method     void Encrypt()
	Equals      Method     bool Equals(System.Object obj)
	GetHashCode Method     int GetHashCode()
	GetType     Method     type GetType()
	SetKey      Method     void SetKey(string Key)
	ToString    Method     string ToString()
	Cipher      Property   byte[] Cipher {get;set;}
	Data        Property   byte[] Data {get;set;}
	Key         Property   byte[] Key {get;}

	> $RC4.SetKey("#S3cur3")
	> $RC4.Data = [Text.Encoding]::ascii.GetBytes("SuperSecretString")
	> $RC4.Encrypt()
	> $RC4.Cipher
	240, 161, 0, 176, 2, 6, 65, 101, 95, 220, 67, 57, 164, 255, 142, 27, 159