Public Class Casteos

    Public Function getCasteo(ByVal tipoReq As Integer, ByVal obtenido As Resultado)
        Dim resultado As Resultado = New Resultado
        If (tipoReq = obtenido.tipo) Then
            Return obtenido
        End If

        If (tipoReq = Constantes.T_CADENA) Then
            resultado.tipo = Constantes.T_CADENA
            resultado.valor = obtenido.valor
            Return resultado
        End If

        If (tipoReq = Constantes.T_ENTERO) Then
            If (obtenido.tipo = Constantes.T_BOOLEAN) Then
                resultado.tipo = Constantes.T_ENTERO
                resultado.valor = Convert.ToString(castBoolToInt(obtenido.valor))
                Return resultado
            End If
            If (obtenido.tipo = Constantes.T_DOBLE) Then
                resultado.tipo = Constantes.T_ENTERO
                resultado.valor = Convert.ToString(castDobleToInt(obtenido.valor))
                Return resultado
            End If
            If (obtenido.tipo = Constantes.T_CARACTER) Then
                resultado.tipo = Constantes.T_ENTERO
                resultado.valor = Convert.ToString(castCharToInt(obtenido.valor))
                Return resultado
            End If
            Return resultado
        End If

        If (tipoReq = Constantes.T_DOBLE) Then
            If (obtenido.tipo = Constantes.T_ENTERO) Then
                resultado.tipo = Constantes.T_DOBLE
                resultado.valor = Convert.ToString(castIntToDouble(obtenido.valor))
                Return resultado
            End If
        End If

        If (tipoReq = Constantes.T_CARACTER) Then
            If (obtenido.tipo = Constantes.T_ENTERO) Then
                resultado.tipo = Constantes.T_CARACTER
                resultado.valor = Convert.ToString(castIntToChar(obtenido.valor))
                Return resultado
            End If
        End If

        Return resultado
    End Function

    Public Function castCharToInt(ByVal cad As String)
        Return Asc(cad)
    End Function

    Public Function castDobleToInt(ByVal cad As String)
        Return CType(castStrToDoble(cad), Integer)
    End Function

    Public Function castIntToDouble(ByVal cad As String)
        Return CType(castStrToInt(cad), Double)
    End Function

    Public Function castIntToChar(ByVal cad As String)
        Dim val As Integer = castStrToInt(cad)
        If (val < 0 Or val > 255) Then
            Return Convert.ToString(Chr(255))
        End If
        Return Convert.ToString(Chr(val))
    End Function

    Public Function castBoolToInt(ByVal cad As String)
        If (cad = "true" Or cad = "1") Then
            Return 1
        End If
        Return 0
    End Function

    Public Function castStrToDoble(ByVal cad As String)
        Return CType(cad, Double)
    End Function

    Public Function castStrToInt(ByVal cad As String)
        Return CType(cad, Integer)
    End Function

    Public Function castStrToBool(ByVal cad As String)
        If (cad = "true" Or cad = "1") Then
            Return True
        End If
        Return False
    End Function

    Public Function obtenerDouble(ByVal op As Resultado)
        Dim val As Double = New Double
        If (op.tipo = Constantes.T_DOBLE) Then
            val = castStrToDoble(op.valor)
        End If
        If (op.tipo = Constantes.T_ENTERO) Then
            val = castIntToDouble(op.valor)
        End If
        If (op.tipo = Constantes.T_CARACTER) Then
            val = castIntToDouble(castCharToInt(op.valor))
        End If
        If (op.tipo = Constantes.T_BOOLEAN) Then
            val = castIntToDouble(castBoolToInt(op.valor))
        End If
        Return val
    End Function

    Public Function obtenerInt(ByVal op As Resultado)
        Dim val As Integer = New Integer
        If (op.tipo = Constantes.T_DOBLE) Then
            val = castDobleToInt(op.valor)
        End If
        If (op.tipo = Constantes.T_ENTERO) Then
            val = castStrToInt(op.valor)
        End If
        If (op.tipo = Constantes.T_CARACTER) Then
            val = castCharToInt(op.valor)
        End If
        If (op.tipo = Constantes.T_BOOLEAN) Then
            val = castBoolToInt(op.valor)
        End If
        Return val
    End Function

End Class
