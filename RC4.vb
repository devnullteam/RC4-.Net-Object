' ARC4 crypto based on work of Joke758:
'   codes-sources.commentcamarche.net/source/41581-rc4-encrypt-decrypt-fonction
'
' Modified to work with byte arrays instead strings, improved speed, minimal optimizations.
' Newbie @ devnull.team - 16/02/06
Public Class RC4
    Private _key As Byte() = {}
    Private _cipher As Byte() = {}
    Private _data As Byte() = {}
    Public ReadOnly Property Key As Byte()
        Get
            Return _key
        End Get
    End Property
    Public Property Cipher As Byte()
        Get
            Return _cipher
        End Get
        Set(value As Byte())
            _cipher = value
        End Set
    End Property
    Public Property Data As Byte()
        Get
            Return _data
        End Get
        Set(value As Byte())
            _data = value
        End Set
    End Property
    Public Sub Encrypt()
        If _data Is Nothing Or _key Is Nothing Then
            MsgBox("There is no data or key to encrypt.", vbCritical)
        Else
            _doEncrypt()
        End If
    End Sub
    Public Sub Decrypt()
        If _data Is Nothing Or _key Is Nothing Then
            MsgBox("There is no cipher or key to decrypt.")
        Else
            _doDecrypt()
        End If
    End Sub
    Private Sub _doDecrypt()
        Dim sbox(256) As Integer
        Dim key(256) As Integer
        Dim temp As Integer
        Dim a As Long
        Dim i As Integer
        Dim j As Integer
        Dim k As Long
        Dim cipherby As Byte

        _data = {}
        i = 0
        j = 0

        _Initialize(_key, key, sbox)

        For a = 0 To UBound(_cipher)
            i = (i + 1) Mod 256
            j = (j + sbox(i)) Mod 256
            temp = sbox(i)
            sbox(i) = sbox(j)
            sbox(j) = temp

            k = sbox((sbox(i) + sbox(j)) Mod 256)

            cipherby = _cipher(a) Xor k
            ReDim Preserve _data(_data.Length)
            _data(UBound(_data)) = cipherby
        Next
    End Sub
    Private Sub _doEncrypt()
        Dim sbox(256) As Integer
        Dim key(256) As Integer
        Dim temp As Integer
        Dim a As Long
        Dim i As Integer
        Dim j As Integer
        Dim k As Integer
        Dim cipherby As Byte

        _cipher = {}
        i = 0
        j = 0

        _Initialize(_key, key, sbox)

        For a = 0 To UBound(_data)
            i = (i + 1) Mod 256
            j = (j + sbox(i)) Mod 256
            temp = sbox(i)
            sbox(i) = sbox(j)
            sbox(j) = temp

            k = sbox((sbox(i) + sbox(j)) Mod 256)
            cipherby = _data(a) Xor k

            ReDim Preserve _cipher(_cipher.Count)
            _cipher(UBound(_cipher)) = cipherby

        Next
    End Sub
    Private Sub _Initialize(ByVal strPwd As Byte(), ByRef key As Integer(), ByRef sbox As Integer())
        Dim tempSwap
        Dim a
        Dim b
        Dim intlength As Long

        intlength = strPwd.Length
        For a = 0 To 255
            key(a) = strPwd(a Mod intlength)
            sbox(a) = a
        Next

        b = 0
        For a = 0 To 255
            b = (b + sbox(a) + key(a)) Mod 256
            tempSwap = sbox(a)
            sbox(a) = sbox(b)
            sbox(b) = tempSwap
        Next
    End Sub
    Public Sub SetKey(ByVal Key As String)
        _key = {}

        For Each c In Key.ToCharArray
            ReDim Preserve _key(_key.Length)
            _key(UBound(_key)) = Asc(c)
        Next
    End Sub
End Class
