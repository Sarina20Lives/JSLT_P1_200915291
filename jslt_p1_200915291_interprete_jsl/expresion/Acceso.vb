Public Class Acceso
    Private entorno As Entorno = Nothing
    
    Public Function getVal(ByRef ent As Entorno, ByVal expresion As Nodo)
        Dim resultado As Resultado = New Resultado

        'Actualizando contexto y ambito
        entorno = New Entorno
        entorno = entorno.crearEntorno(ent)

        If (expresion.subrol = Constantes.SR_ACTUAL) Then
            Return entorno.ambito.getValActual()
        End If
        If (expresion.subrol = Constantes.SR_VAR) Then
            Return obtenerValor(expresion.cad)
        End If
        If (expresion.subrol = Constantes.SR_ARR) Then
            Return obtenerValor(expresion.cad, expresion.getHijo(0))
        End If
        If (expresion.subrol = Constantes.SR_RUTA) Then
            Return obtenerValor(expresion)
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
        Return entorno.ambito.getValDeObj(nombre, casteo.castStrToInt(posicion.valor))
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
        Return entorno.ambito.getValDeColl(nombre)
    End Function


    Public Function obtenerValor(ByVal expresion As Nodo)
        Dim resultado As Resultado = New Resultado
        If (expresion.hijos.Count <> 3) Then
            Return resultado
        End If
        Dim exp As Expresion = New Expresion
        Dim casteo As Casteos = New Casteos
        Dim raiz As Nodo = expresion.getHijo(0)
        Dim obj As Nodo = expresion.getHijo(1)
        Dim atri As Nodo = expresion.getHijo(2)
        If (raiz.subrol <> Constantes.SR_VAR Or obj.subrol <> Constantes.SR_VAR Or atri.subrol <> Constantes.SR_ARR) Then
            Return resultado
        End If
        Dim posicion As Resultado = exp.resolver(entorno, atri.getHijo(0))
        If (posicion.tipo <> Constantes.T_ENTERO) Then
            'Error, se requiere un valor entero para la posición
            Return resultado
        End If
        Return entorno.raiz.getValDeRuta(raiz.cad, obj.cad, atri.cad, casteo.castStrToInt(posicion.valor))
    End Function

End Class
