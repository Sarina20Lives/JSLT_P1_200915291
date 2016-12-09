<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Banalizar = New System.Windows.Forms.Button()
        Me.RTBentrada = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'Banalizar
        '
        Me.Banalizar.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Banalizar.Location = New System.Drawing.Point(359, 304)
        Me.Banalizar.Name = "Banalizar"
        Me.Banalizar.Size = New System.Drawing.Size(83, 26)
        Me.Banalizar.TabIndex = 0
        Me.Banalizar.Text = "Analizar"
        Me.Banalizar.UseVisualStyleBackColor = True
        '
        'RTBentrada
        '
        Me.RTBentrada.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RTBentrada.Location = New System.Drawing.Point(12, 30)
        Me.RTBentrada.Name = "RTBentrada"
        Me.RTBentrada.Size = New System.Drawing.Size(819, 255)
        Me.RTBentrada.TabIndex = 1
        Me.RTBentrada.Text = ""
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(843, 396)
        Me.Controls.Add(Me.RTBentrada)
        Me.Controls.Add(Me.Banalizar)
        Me.Name = "Form1"
        Me.Text = "JSLT_P1_200915291"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Banalizar As System.Windows.Forms.Button
    Friend WithEvents RTBentrada As System.Windows.Forms.RichTextBox

End Class
