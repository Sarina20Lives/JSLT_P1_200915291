Public Class PtrJson

    Public rol As Integer = Constantes.ERR
    Public valor As String = ""
    Public fila As Integer = -1
    Public column As Integer = -1
    Public padre As PtrJson = Nothing
    Public hijos As ArrayList = New ArrayList

    Public Function crearHoja(ByVal valor As String, ByVal fila As Integer, ByVal column As Integer)
        Dim ptr As PtrJson = New PtrJson
        ptr.rol = Constantes.R_JSVAL
        ptr.valor = valor
        ptr.fila = fila
        ptr.column = column
        Return ptr
    End Function

    Public Function crearAtributo(ByVal valor As String, ByVal fila As Integer, ByVal column As Integer, ByRef hijo As PtrJson)
        Dim ptr As PtrJson = New PtrJson
        ptr.rol = Constantes.R_JSATR
        ptr.valor = valor
        ptr.fila = fila
        ptr.column = column
        ptr.hijos.Add(hijo)
        hijo.padre = ptr
        Return ptr
    End Function

    Public Function crearArr(ByVal rol As Integer, ByVal valor As String, ByVal fila As Integer, ByVal column As Integer, ByRef hijos As ArrayList)
        Dim ptr As PtrJson = New PtrJson
        ptr.rol = rol
        ptr.valor = valor
        ptr.fila = fila
        ptr.column = column
        Dim obj As PtrJson
        For Each obj In hijos
            ptr.hijos.Add(obj)
            obj.padre = ptr
        Next obj
        Return ptr
    End Function

    Public Function generarList(ByVal ptr As PtrJson)
        Dim lista As ArrayList = New ArrayList
        lista.Add(ptr)
        Return lista
    End Function

    Public Function preList(ByVal lista As ArrayList, ByVal ptr As PtrJson)
        lista.Insert(0, ptr)
        Return lista
    End Function

    Public Function addList(ByVal lista As ArrayList, ByVal ptr As PtrJson)
        lista.Add(ptr)
        Return lista
    End Function

    Public Function getHijo(ByVal pos As Integer)
        If (Me.hijos.Count >= pos) Then
            Return CType(Me.hijos.Item(pos), PtrJson)
        End If
        Return Nothing
    End Function

End Class
