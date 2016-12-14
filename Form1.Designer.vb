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
        Me.PanelBotones = New System.Windows.Forms.Panel()
        Me.PanelAuxiliar = New System.Windows.Forms.Panel()
        Me.Bnuevo = New System.Windows.Forms.Button()
        Me.Babrir = New System.Windows.Forms.Button()
        Me.Bguardar = New System.Windows.Forms.Button()
        Me.BguardarComo = New System.Windows.Forms.Button()
        Me.TabArchivos = New System.Windows.Forms.TabControl()
        Me.PanelBotones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Banalizar
        '
        Me.Banalizar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Banalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Banalizar.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Banalizar.Image = Global.JSLT_P1_200915291.My.Resources.Resources.icono_3D_ejecutar
        Me.Banalizar.Location = New System.Drawing.Point(3, 3)
        Me.Banalizar.Name = "Banalizar"
        Me.Banalizar.Size = New System.Drawing.Size(63, 62)
        Me.Banalizar.TabIndex = 0
        Me.Banalizar.UseVisualStyleBackColor = True
        '
        'PanelBotones
        '
        Me.PanelBotones.Controls.Add(Me.BguardarComo)
        Me.PanelBotones.Controls.Add(Me.Bguardar)
        Me.PanelBotones.Controls.Add(Me.Babrir)
        Me.PanelBotones.Controls.Add(Me.Bnuevo)
        Me.PanelBotones.Controls.Add(Me.Banalizar)
        Me.PanelBotones.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelBotones.Location = New System.Drawing.Point(0, 0)
        Me.PanelBotones.Name = "PanelBotones"
        Me.PanelBotones.Size = New System.Drawing.Size(78, 472)
        Me.PanelBotones.TabIndex = 2
        '
        'PanelAuxiliar
        '
        Me.PanelAuxiliar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelAuxiliar.Location = New System.Drawing.Point(78, 342)
        Me.PanelAuxiliar.Name = "PanelAuxiliar"
        Me.PanelAuxiliar.Size = New System.Drawing.Size(765, 130)
        Me.PanelAuxiliar.TabIndex = 3
        '
        'Bnuevo
        '
        Me.Bnuevo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Bnuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bnuevo.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bnuevo.Image = Global.JSLT_P1_200915291.My.Resources.Resources.icono_nuevo
        Me.Bnuevo.Location = New System.Drawing.Point(3, 71)
        Me.Bnuevo.Name = "Bnuevo"
        Me.Bnuevo.Size = New System.Drawing.Size(63, 62)
        Me.Bnuevo.TabIndex = 4
        Me.Bnuevo.UseVisualStyleBackColor = True
        '
        'Babrir
        '
        Me.Babrir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Babrir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Babrir.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Babrir.Image = Global.JSLT_P1_200915291.My.Resources.Resources.icono_abrir
        Me.Babrir.Location = New System.Drawing.Point(3, 139)
        Me.Babrir.Name = "Babrir"
        Me.Babrir.Size = New System.Drawing.Size(63, 62)
        Me.Babrir.TabIndex = 5
        Me.Babrir.UseVisualStyleBackColor = True
        '
        'Bguardar
        '
        Me.Bguardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Bguardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Bguardar.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bguardar.Image = Global.JSLT_P1_200915291.My.Resources.Resources.icono_guardar
        Me.Bguardar.Location = New System.Drawing.Point(3, 207)
        Me.Bguardar.Name = "Bguardar"
        Me.Bguardar.Size = New System.Drawing.Size(63, 62)
        Me.Bguardar.TabIndex = 6
        Me.Bguardar.UseVisualStyleBackColor = True
        '
        'BguardarComo
        '
        Me.BguardarComo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BguardarComo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BguardarComo.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BguardarComo.Image = Global.JSLT_P1_200915291.My.Resources.Resources.icono_guardarComo
        Me.BguardarComo.Location = New System.Drawing.Point(3, 275)
        Me.BguardarComo.Name = "BguardarComo"
        Me.BguardarComo.Size = New System.Drawing.Size(63, 62)
        Me.BguardarComo.TabIndex = 7
        Me.BguardarComo.UseVisualStyleBackColor = True
        '
        'TabArchivos
        '
        Me.TabArchivos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabArchivos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabArchivos.Location = New System.Drawing.Point(82, 5)
        Me.TabArchivos.Name = "TabArchivos"
        Me.TabArchivos.SelectedIndex = 0
        Me.TabArchivos.Size = New System.Drawing.Size(759, 331)
        Me.TabArchivos.TabIndex = 4
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(843, 472)
        Me.Controls.Add(Me.TabArchivos)
        Me.Controls.Add(Me.PanelAuxiliar)
        Me.Controls.Add(Me.PanelBotones)
        Me.Name = "Form1"
        Me.Text = "JSLT_P1_200915291"
        Me.PanelBotones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Banalizar As System.Windows.Forms.Button
    Friend WithEvents PanelBotones As System.Windows.Forms.Panel
    Friend WithEvents BguardarComo As System.Windows.Forms.Button
    Friend WithEvents Bguardar As System.Windows.Forms.Button
    Friend WithEvents Babrir As System.Windows.Forms.Button
    Friend WithEvents Bnuevo As System.Windows.Forms.Button
    Friend WithEvents PanelAuxiliar As System.Windows.Forms.Panel
    Friend WithEvents TabArchivos As System.Windows.Forms.TabControl

End Class
