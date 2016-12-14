Public Class APlantilla

    Private entorno As Entorno = Nothing

    Public Sub resolverAPlantilla(ByRef ent As Entorno, ByVal nodo As Nodo)
        'Actualizando contexto y ambito
        entorno = New Entorno
        entorno = entorno.crearEntorno(ent)


    End Sub


    Public Function ascNombre(ByVal ptr As PtrJson, ByRef nombre As String)
        If (ptr.rol = Constantes.R_JSATRI) Then
            nombre = ascNombre(ptr.padre, nombre) + ptr.nombre
        End If
        If (ptr.rol = Constantes.R_JSCOLL) Then
            nombre = ascNombre(ptr.padre, nombre) + "@"
        End If
        If (ptr.rol = Constantes.R_JSOBJ) Then
            nombre = ascNombre(ptr.padre, nombre) + ptr.nombre
        End If
        If (ptr.rol = Constantes.R_JSRAIZ) Then
            nombre = "@" + ptr.nombre + "@"
        End If
        Return nombre
    End Function

End Class
