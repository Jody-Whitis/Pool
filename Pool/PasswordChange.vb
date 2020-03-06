﻿Public Class PasswordChange
    Dim passwordTheme As New ScoreTheme(Me)
    Dim passwordUpdate As New Authenticate(UserMod.UserEmail, UserMod.Password, UserMod.IsLoggedIn)
    Private Sub PasswordChange_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        passwordTheme.Screen = ScoreTheme.AppState.edit
        passwordTheme.SetBackground(Me)
        passwordTheme.SetTBox(New TextBox() {txtNewPassword, txtNewPasswordConfirm, txtCurrentPassword})
        passwordTheme.SetButtons(New Button() {btnUpdatePassword, btnCancel})
        lblUpdate.ForeColor = Color.Lime
    End Sub

    Private Sub btnUpdatePassword_Click(sender As Object, e As EventArgs) Handles btnUpdatePassword.Click
        Dim isUpdated As Boolean = False
        lblUpdate.ForeColor = Color.Lime
        If txtNewPassword.Text.Equals(txtNewPasswordConfirm.Text) Then
            isUpdated = passwordUpdate.ILogin_UpdatePassword(txtNewPassword.Text, txtCurrentPassword.Text)
        End If
        If isUpdated.Equals(True) Then
            UserMod.PreviousForm.Show()
            Me.Close()
        Else
            lblUpdate.ForeColor = Color.Red
            lblUpdate.Text = "Incorrect Current/New Password"
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If UserMod.PreviousForm IsNot Nothing Then
            UserMod.PreviousForm.Show()
        Else
            Home.Activate()
            Home.Show()
        End If
        Me.Close()
    End Sub
End Class