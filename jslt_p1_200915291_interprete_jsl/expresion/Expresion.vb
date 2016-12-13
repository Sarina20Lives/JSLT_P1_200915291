Public Class Expresion

    Private entorno As Entorno = Nothing

    Public Function resolver(ByRef ent As Entorno, ByVal expresion As Nodo)
        Dim resultado As Resultado = New Resultado
        'Actualizando contexto y ambito
        entorno = New Entorno
        entorno.ctxGlobal = ent.ctxGlobal
        entorno.ctxLocal = ent.ctxLocal
        entorno.ambito = ent.ambito
        entorno.raiz = ent.raiz
        Select Case expresion.rol
            Case Constantes.R_ARITMETICA
                Dim arit As Aritmetica = New Aritmetica
                Return arit.resolverAritmetica(entorno, expresion)
            Case Constantes.R_LOGICA
                Dim log As Logica = New Logica
                Return log.resolverLogica(entorno, expresion)
            Case Constantes.R_RELACIONAL
                Dim rel As Relacional = New Relacional
                Return rel.resolverRelacional(entorno, expresion)
            Case Constantes.R_JSL
                Return getVal(expresion)
            Case Constantes.R_ACCESO
                Dim acceso As Acceso = New Acceso
                Return acceso.getVal(entorno, expresion)
            Case Constantes.R_OPERADOR
                resultado.tipo = expresion.tipo
                resultado.valor = expresion.cad
                Return resultado
        End Select
        Return resultado
    End Function

    Private Function getVal(ByVal expresion As Nodo)
        Dim resultado As Resultado = New Resultado
        If (expresion.subrol <> Constantes.SR_GETVAL) Then
            Return resultado
        End If
        Dim acceso As Acceso = New Acceso
        Return acceso.getVal(entorno, CType(expresion.getHijo(0), Nodo))
    End Function

End Class
