Public Class Acceso
    Private entorno As Entorno = Nothing
    
    Public Function getVal(ByRef ent As Entorno, ByVal expresion As Nodo)
        Dim resultado As Resultado = New Resultado

        'Actualizando contexto y ambito
        entorno = New Entorno
        entorno.ctxGlobal = ent.ctxGlobal
        entorno.ctxLocal = ent.ctxLocal
        entorno.ambito = ent.ambito
        entorno.raiz = ent.raiz

        If (expresion.subrol = Constantes.SR_RAIZ) Then
            'Error, la raiz no es un valor
            Return resultado
        End If
        If (expresion.subrol = Constantes.SR_PADRE) Then
            'Error, Todo padre no es un valor
            Return resultado
        End If
        If (expresion.subrol = Constantes.SR_COLLECTION) Then
            'Error, Una coleccion no posee un valor puntual
            Return resultado
        End If
        If (expresion.subrol = Constantes.SR_ACTUAL) Then
            Dim val As String = CType(entorno.ambito, PtrJson).getVal()
            If (val = "$#$ERROR$#$") Then
                'Error, El ambito actual no es un atributo
                Return resultado
            End If
            Return definirVal(val)
        End If
        If (expresion.subrol = Constantes.SR_VAR) Then
            Return obtenerValor(expresion.cad)
        End If
        If (expresion.subrol = Constantes.SR_ARR) Then
            Return obtenerValor(expresion.cad, expresion.getHijo(0))
        End If
        If (expresion.subrol = Constantes.SR_RUTA) Then
            'Resolver Ruta
            If (expresion.hijos.Count <> 3) Then
                'La ruta no hace referencia a un atributo
                Return resultado
            End If

        End If

        Return resultado
    End Function


    Public Function obtenerValor(ByVal nombre As String, ByVal pos As Nodo)
        Dim resultado As Resultado = New Resultado
        Dim posicion As Resultado = New Resultado
        Dim exp As Expresion = New Expresion
        Dim casteo As Casteos = New Casteos
        posicion = exp.resolver(entorno, pos)
        If (posicion.tipo <> Constantes.T_ENTERO) Then
            'Error, se requiere un valor entero para la posición
            Return resultado
        End If
        Dim val As String = CType(entorno.ambito, PtrJson).getVal(nombre, casteo.castStrToInt(posicion.valor))
        If (val = "$#$ERROR$#$") Then
            'Error, El ambito actual no posee el atributo buscado
            Return Resultado
        End If
        Return definirVal(val)
    End Function

    Public Function obtenerValor(ByVal nombre As String)
        Dim resultado As Resultado = New Resultado
        Dim simbolo As Simbolo
        For Each simbolo In entorno.ctxLocal
            If (simbolo.nombre = nombre And simbolo.instancia) Then
                resultado.valor = simbolo.valor
                resultado.tipo = simbolo.tipo
                Return resultado
            End If
        Next
        For Each simbolo In entorno.ctxGlobal
            If (simbolo.nombre = nombre And simbolo.instancia) Then
                resultado.valor = simbolo.valor
                resultado.tipo = simbolo.tipo
                Return resultado
            End If
        Next

        Dim val As String = CType(entorno.ambito, PtrJson).getVal(nombre, -1)
        If (val = "$#$ERROR$#$") Then
            'Error, El ambito actual no posee el atributo buscado
            Return resultado
        End If
        Return definirVal(val)

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


End Class
