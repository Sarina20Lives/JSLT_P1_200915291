Public Class PtrJson

    Public rol As Integer = Constantes.ERR
    Public nombre As String = ""
    Public valor As String = ""
    Public fila As Integer = -1
    Public column As Integer = -1
    Public padre As PtrJson = Nothing
    Public hijos As ArrayList = New ArrayList

    Public Function crearAtri(ByVal nombre As String, ByVal val As String, ByVal fila As Integer, ByVal column As Integer)
        Dim ptr As PtrJson = New PtrJson
        ptr.rol = Constantes.R_JSATRI
        ptr.nombre = nombre
        ptr.valor = val
        ptr.fila = fila
        ptr.column = column
        hijos = New ArrayList
        Return ptr
    End Function

    Public Function crearJSon(ByVal rol As Integer, ByVal nombre As String, ByVal fila As Integer, ByVal column As Integer, ByRef hijos As ArrayList)
        Dim ptr As PtrJson = New PtrJson
        ptr.rol = rol
        ptr.nombre = nombre
        ptr.valor = ""
        ptr.fila = fila
        ptr.column = column
        ptr.hijos = New ArrayList
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
        If (Me.hijos.Count <= pos) Then
            Return Nothing
        End If
        Return Me.hijos.Item(pos)
    End Function


    Public Function getValDeRuta(ByVal raiz As String, ByVal obj As String, ByVal atri As String, ByVal pos As Integer)
        Dim resultado As Resultado = New Resultado
        If (Me.nombre <> raiz) Then
            Return resultado
        End If
        Dim objs As ArrayList = Me.getHijos(obj)
        Dim atris As ArrayList = New ArrayList
        Dim objeto As PtrJson
        For Each objeto In objs
            atris.AddRange(objeto.getHijos(atri))
        Next
        If (pos < atris.Count) Then
            Return CType(atris.Item(pos), PtrJson).getValActual()
        End If
        Return resultado
    End Function

    Public Function getValDeObj(ByVal nombre As String, ByVal pos As Integer)
        Dim resultado As Resultado = New Resultado
        If (Me.rol <> Constantes.R_JSOBJ) Then
            Return resultado
        End If
        Dim hijos As ArrayList = getHijos(nombre)
        If (hijos.Count > pos) Then
            Return CType(hijos.Item(pos), PtrJson).getValActual()
        End If
        Return resultado
    End Function


    Public Function getValDeColl(ByVal nombre As String)
        Dim resultado As Resultado = New Resultado
        If (Me.rol <> Constantes.R_JSCOLL) Then
            Return Resultado
        End If
        Dim hijo As PtrJson
        For Each hijo In Me.hijos
            If (hijo.nombre = nombre) Then
                Return definirVal(hijo.valor)
            End If
        Next
        Return resultado
    End Function

    Public Function getValActual()
        Dim resultado As Resultado = New Resultado
        If (Me.rol <> Constantes.R_JSATRI) Then
            Return resultado
        End If
        Return definirVal(Me.valor)
    End Function


    Public Function definirVal(ByVal valor As String)
        Dim resultado As Resultado = New Resultado
        Dim temp As String = valor.Replace(".", ",")
        If (IsNumeric(temp)) Then
            resultado.valor = temp
            resultado.tipo = Constantes.T_ENTERO
            If (valor.Contains(",")) Then
                resultado.tipo = Constantes.T_DOBLE
            End If
            Return resultado
        End If
        resultado.valor = valor
        resultado.tipo = Constantes.T_CADENA
        Return resultado
    End Function



    'ID[POS] PARA CAMBIO DE AMBITO
    Public Function getHijo(ByVal nombre As String, ByVal pos As Integer)
        Dim hijo As PtrJson
        Dim contador As Integer = 0
        If (Me.rol = Constantes.R_JSRAIZ) Then
            For Each hijo In Me.hijos
                If (hijo.nombre = nombre And contador = pos) Then
                    Return hijo
                End If
                contador += 1
            Next
        End If
        Return Nothing
    End Function

    '@@ID PARA EL BUCLE FOR
    Public Function getHijos(ByVal nombre As String)
        Dim lista As ArrayList = New ArrayList
        Dim hijo As PtrJson
        If (Me.rol = Constantes.R_JSRAIZ Or Me.rol = Constantes.R_JSCOLL) Then
            For Each hijo In Me.hijos
                If (hijo.nombre = nombre) Then
                    lista.Add(hijo)
                End If
            Next
            Return lista
        End If
        If (Me.rol = Constantes.R_JSOBJ) Then
            For Each hijo In Me.hijos
                lista.AddRange(hijo.getHijos(nombre))
            Next
            Return lista
        End If
        Return lista
    End Function


End Class
