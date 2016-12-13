Public Class Sentencia
    Private entorno As Entorno = Nothing

    Public Sub resolver(ByRef ent As Entorno, ByVal sentencia As Nodo)
        'Actualizando contexto y ambito
        entorno = New Entorno
        entorno.ctxGlobal = ent.ctxGlobal
        entorno.ctxLocal = ent.ctxLocal
        entorno.ambito = ent.ambito
        entorno.raiz = ent.raiz
        Select Case sentencia.rol
            Case Constantes.R_HTML
                Dim html As EtqHtml = New EtqHtml
                html.resolver(entorno, sentencia)
            Case Constantes.R_JSL
                resolverJsl(sentencia)
        End Select
    End Sub

    Public Sub resolverJsl(ByVal sentencia As Nodo)
        Dim asignacion As Asignar = New Asignar
        Select Case sentencia.subrol
            Case Constantes.SR_APLANTILLA
            Case Constantes.SR_ASIG
                asignacion.resolverAsig(entorno, sentencia)
            Case Constantes.SR_CONCAT
                asignacion.resolverConcat(entorno, sentencia)
            Case Constantes.SR_POS_DEC
                asignacion.resolverPosDec(entorno, sentencia)
            Case Constantes.SR_POS_INC
                asignacion.resolverPosInc(entorno, sentencia)
            Case Constantes.SR_FOR
            Case Constantes.SR_IF
                Dim fif As FlujoIf = New FlujoIf
                fif.resolverIf(entorno, sentencia)
            Case Constantes.SR_SWITCH
                Dim fswitch As FlujoSwitch = New FlujoSwitch
                fswitch.resolverSwitch(entorno, sentencia)
            Case Constantes.SR_DECLARE
                Dim declarre As Declarar = New Declarar
                declarre.resolverDeclare(entorno, sentencia, False)
            Case Constantes.SR_GETVAL
                Dim getval As GetVal = New GetVal
                getval.resolver(entorno, sentencia.getHijo(0))
        End Select
    End Sub
End Class
