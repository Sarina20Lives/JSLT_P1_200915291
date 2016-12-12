Public Class ComprobacionTipos

    Public Function tipoRelacional(ByVal tipo1 As Integer, ByVal tipo2 As Integer)
        If (tipo1 = Constantes.T_ENTERO) Then
            If (tipo2 = Constantes.T_ENTERO Or tipo2 = Constantes.T_DOBLE Or
                tipo2 = Constantes.T_CARACTER Or tipo2 = Constantes.T_BOOLEAN) Then
                Return Constantes.T_BOOLEAN
            End If
        End If
        If (tipo1 = Constantes.T_CARACTER) Then
            If (tipo2 = Constantes.T_ENTERO Or tipo2 = Constantes.T_CARACTER) Then
                Return Constantes.T_BOOLEAN
            End If
        End If
        If (tipo1 = Constantes.T_DOBLE) Then
            If (tipo2 = Constantes.T_ENTERO Or tipo2 = Constantes.T_DOBLE) Then
                Return Constantes.T_BOOLEAN
            End If
        End If
        If (tipo1 = Constantes.T_BOOLEAN) Then
            If (tipo2 = Constantes.T_ENTERO Or tipo2 = Constantes.T_BOOLEAN ) Then
                Return Constantes.T_BOOLEAN
            End If
        End If
        Return Constantes.ERR
    End Function

    Public Function tipoVariacion(ByVal tipo As Integer)
        If (tipo = Constantes.ERR Or tipo = Constantes.T_CADENA Or tipo = Constantes.T_BOOLEAN) Then
            Return Constantes.ERR
        End If
        Return tipo
    End Function
End Class
