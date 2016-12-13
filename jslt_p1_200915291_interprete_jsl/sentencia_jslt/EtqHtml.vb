Public Class EtqHtml
    Private entorno As Entorno = Nothing
    Private manArch As ManejoArchivos = New ManejoArchivos

    Public Sub resolver(ByRef ent As Entorno, ByVal html As Nodo)
        'Actualizando contexto y ambito
        entorno = New Entorno
        entorno.ctxGlobal = ent.ctxGlobal
        entorno.ctxLocal = ent.ctxLocal
        entorno.ambito = ent.ambito
        entorno.raiz = ent.raiz

        Select Case html.subrol
            Case Constantes.SR_HTML
                manArch.appendHtml("<html>" + vbCrLf)
                resolverSentencias(html)
                manArch.appendHtml("</html>" + vbCrLf)
            Case Constantes.SR_BODY
                manArch.appendHtml("<body>" + vbCrLf)
                resolverSentencias(html)
                manArch.appendHtml("</body>" + vbCrLf)
            Case Constantes.SR_HEAD
                manArch.appendHtml("<head>" + vbCrLf)
                resolverSentencias(html)
                manArch.appendHtml("</head>" + vbCrLf)
            Case Constantes.SR_H1
                manArch.appendHtml("<hl>")
                resolverSentencias(html)
                manArch.appendHtml("</hl>" + vbCrLf)
            Case Constantes.SR_H2
                manArch.appendHtml("<h2>")
                resolverSentencias(html)
                manArch.appendHtml("</h2>" + vbCrLf)
            Case Constantes.SR_H3
                manArch.appendHtml("<h3>")
                resolverSentencias(html)
                manArch.appendHtml("</h3>" + vbCrLf)
            Case Constantes.SR_H4
                manArch.appendHtml("<h4>")
                resolverSentencias(html)
                manArch.appendHtml("</h4>" + vbCrLf)
            Case Constantes.SR_H5
                manArch.appendHtml("<h5>")
                resolverSentencias(html)
                manArch.appendHtml("</h5>" + vbCrLf)
            Case Constantes.SR_H6
                manArch.appendHtml("<h6>")
                resolverSentencias(html)
                manArch.appendHtml("</h6>" + vbCrLf)
            Case Constantes.SR_TABLE
                manArch.appendHtml("<table" + html.cad + vbCrLf)
                resolverSentencias(html)
                manArch.appendHtml("</table>" + vbCrLf)
            Case Constantes.SR_P
                manArch.appendHtml("<p>")
                resolverSentencias(html)
                manArch.appendHtml("</p>" + vbCrLf)
            Case Constantes.SR_B
                manArch.appendHtml("<b>")
                resolverSentencias(html)
                manArch.appendHtml("</b>" + vbCrLf)
            Case Constantes.SR_I
                manArch.appendHtml("<i>")
                resolverSentencias(html)
                manArch.appendHtml("</i>" + vbCrLf)
            Case Constantes.SR_TITLE
                manArch.appendHtml("<title>")
                resolverSentencias(html)
                manArch.appendHtml("</title>" + vbCrLf)
            Case Constantes.SR_TR
                manArch.appendHtml("<tr" + html.cad + vbCrLf)
                resolverSentencias(html)
                manArch.appendHtml("</tr>" + vbCrLf)
            Case Constantes.SR_TH
                manArch.appendHtml("<th" + html.cad + vbCrLf)
                resolverSentencias(html)
                manArch.appendHtml("</th>" + vbCrLf)
            Case Constantes.SR_TD
                manArch.appendHtml("<td" + html.cad + vbCrLf)
                resolverSentencias(html)
                manArch.appendHtml("</td>" + vbCrLf)
        End Select
    End Sub

    Private Sub resolverSentencias(ByVal html As Nodo)
        Dim sentencia As Sentencia = Nothing
        Dim stcia As Nodo
        For Each stcia In html.hijos
            sentencia = New Sentencia
            sentencia.resolver(entorno, stcia)
        Next
    End Sub

End Class
