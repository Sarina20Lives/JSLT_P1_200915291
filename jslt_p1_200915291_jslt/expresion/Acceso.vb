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
        If (expresion.subrol = Constantes.SR_ACTUAL) Then
            If (CType(entorno.ambito, PtrJson).rol = Constantes.R_JSVAL) Then
                Return definirVal(CType(entorno.ambito, PtrJson).valor)
            End If
            'Error, el ambito actual no es un valor
            Return resultado
        End If
        If (expresion.subrol = Constantes.SR_RUTA) Then
            'Caso de una posible variable
            If (expresion.hijos.Count = 1) Then
                Dim nodo As Nodo = expresion.getHijo(0)
                If (nodo.rol = Constantes.R_VAR And nodo.subrol = Constantes.SR_DIRECTO) Then
                    Return obtenerValor(nodo.cad)
                End If
            End If
            'Todos los demás casos se deben buscar en Json
        End If

        Return resultado
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
        ' Falta el caso de buscar en ambito

        Return resultado
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
