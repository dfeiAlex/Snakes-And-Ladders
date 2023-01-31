Public Class Form1
    Dim game = New Game()

    Private Sub btnDie1_Click(sender As Object, e As EventArgs) Handles btnDie1.Click
        Dim randomNumber As Integer = game.rollDie()
        game.setDiePic(randomNumber, picDie1)
    End Sub

    Private Sub btnDie2_Click(sender As Object, e As EventArgs) Handles btnDie2.Click
        Dim randomNumber As Integer = game.rollDie()
        game.setDiePic(randomNumber, picDie2)
    End Sub
End Class
