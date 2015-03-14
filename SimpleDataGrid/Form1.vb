Option Strict On
Option Explicit On

Imports System.Data.SqlClient

Public Class Form1

    'A DataAdapter gives us the ability to get data from a database and send changes back to the database.
    Dim fruitDataAdapter As SqlDataAdapter = Nothing

    'The DataTable that will actually contain the data that the GridView is displaying.
    Dim fruitDataTable As DataTable = Nothing

    'A DataTable that is the source for the grid's combobox. We don't need to update this data, it is just
    'there to facilitate binding the [GrowsOn] field of the table.
    Dim growsOnTable As DataTable = Nothing

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        growsOnTable = New DataTable()

        'First get data into the combobox datasource and bind it.
        PopulateGrowsOnTable()

        'Now get all data from database in table [Fruit] and bind the grid.
        bindGrid()

    End Sub

    ''' <summary>
    ''' Fills a DataTable with data from table [GrowsOn] and binds it to
    ''' the DataGridView column.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub PopulateGrowsOnTable()

        'Creates the ConnectionString. In production this would more likely come from App.config
        Dim conxnString As String = getConnectionString()

        'The SQL command that gets the data. In production this would more likely be a 
        'stored procedure or Entity data model.
        Dim cmdString As String = "SELECT [Id], [GrowsOn] FROM [GrowsOn];"

        'Typical connection, command, adapter pattern within 'Using' blocks to properly Dispose
        'the resources when done.
        Using conxn As New SqlConnection(conxnString)
            Using cmd As New SqlCommand(cmdString, conxn)
                Using sda As New SqlDataAdapter(cmd)
                    sda.Fill(growsOnTable)
                End Using
            End Using
        End Using

        'Need a referencce to the combobox column as a DataGridViewComboBoxColumn so we can access
        'the ValueMember and DisplayMember properties.
        Dim growsOnColumn As DataGridViewComboBoxColumn = _
            DirectCast(FruitGridView.Columns("colFruitGrowsOn"), System.Windows.Forms.DataGridViewComboBoxColumn)

        'Tells the combobox which column in the bound data is the value to save in the database
        'and which column is the value to display to the user.
        growsOnColumn.ValueMember = "Id"
        growsOnColumn.DisplayMember = "GrowsOn"

        'Binds the combobox to the GrowsOn data
        growsOnColumn.DataSource = growsOnTable

    End Sub

    ''' <summary>
    ''' Binds the DataGridView and sets up all the plumbing to Insert, Update and Delete.
    ''' This is a lot of work and can be done without code but it is good to understand how it works.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub bindGrid()

        'Sets the appropriate properties on the grid columns to accept data binding.
        setColumnProperties()

        fruitDataAdapter = New SqlDataAdapter()
        fruitDataTable = New DataTable()

        Dim conxn As New SqlConnection(getConnectionString())

        'Add commands to the DataAdapter. These should be stored procedures in production.

        'The select command is responsible for retrieving the data only. This one has no parameters because we
        'want all rows from the database.
        fruitDataAdapter.SelectCommand = New SqlCommand("SELECT [Id], [FruitName], [FruitColor], [FruitGrowsOn], [FruitIsYummy] FROM [Fruit];", conxn)
        fruitDataAdapter.Fill(fruitDataTable)

        'The INSERT command is necessary if you want to allow inserting of rows
        fruitDataAdapter.InsertCommand = New SqlCommand("INSERT INTO [Fruit] ([FruitName], [FruitColor], [FruitGrowsOn], [FruitIsYummy]) VALUES(@fruitname,  @fruitcolor,@fruitgrowson,@fruitisyummy)", conxn)

        Dim insParamFruitName As SqlParameter = New SqlParameter("@fruitname", SqlDbType.NVarChar)
        insParamFruitName.SourceColumn = "FruitName"
        fruitDataAdapter.InsertCommand.Parameters.Add(insParamFruitName)

        Dim insParamFruitColor As SqlParameter = New SqlParameter("@fruitcolor", SqlDbType.NVarChar)
        insParamFruitColor.SourceColumn = "FruitColor"
        fruitDataAdapter.InsertCommand.Parameters.Add(insParamFruitColor)

        Dim insParamFruitGrowsOn As SqlParameter = New SqlParameter("@fruitgrowson", SqlDbType.Int)
        insParamFruitGrowsOn.SourceColumn = "FruitGrowsOn"
        fruitDataAdapter.InsertCommand.Parameters.Add(insParamFruitGrowsOn)

        Dim insParamFruitIsYummy As SqlParameter = New SqlParameter("@fruitisyummy", SqlDbType.Bit)
        insParamFruitIsYummy.SourceColumn = "FruitIsYummy"
        fruitDataAdapter.InsertCommand.Parameters.Add(insParamFruitIsYummy)

        'No need for an Id parameter because it is defined as IDENTITY so it will create itself in the database

        'The UPDATE command is necessary if you want to update rows
        fruitDataAdapter.UpdateCommand = _
            New SqlCommand("UPDATE [Fruit] SET [FruitName] = @fruitname, [FruitColor] = @fruitcolor, [FruitGrowsOn] = @fruitgrowson, [FruitIsYummy] = @fruitisyummy WHERE [Id] = @fruitid;", conxn)

        Dim updParamFruitName As SqlParameter = New SqlParameter("@fruitname", SqlDbType.NVarChar)
        updParamFruitName.SourceColumn = "FruitName"
        fruitDataAdapter.UpdateCommand.Parameters.Add(updParamFruitName)

        Dim updParamFruitColor As SqlParameter = New SqlParameter("@fruitcolor", SqlDbType.NVarChar)
        updParamFruitColor.SourceColumn = "FruitColor"
        fruitDataAdapter.UpdateCommand.Parameters.Add(updParamFruitColor)

        Dim updParamFruitGrowsOn As SqlParameter = New SqlParameter("@fruitgrowson", SqlDbType.Int)
        updParamFruitGrowsOn.SourceColumn = "FruitGrowsOn"
        fruitDataAdapter.UpdateCommand.Parameters.Add(updParamFruitGrowsOn)

        Dim updParamFruitIsYummy As SqlParameter = New SqlParameter("@fruitisyummy", SqlDbType.Bit)
        updParamFruitIsYummy.SourceColumn = "FruitIsYummy"
        fruitDataAdapter.UpdateCommand.Parameters.Add(updParamFruitIsYummy)

        Dim updParamFruitId As SqlParameter = New SqlParameter("@fruitid", SqlDbType.Int)
        updParamFruitId.SourceColumn = "Id"
        fruitDataAdapter.UpdateCommand.Parameters.Add(updParamFruitId)

        'DELECT Command is necessary if you want to enable delete of rows
        fruitDataAdapter.DeleteCommand = New SqlCommand("DELETE FROM [Fruit] WHERE [Id] = @fruitid", conxn)

        Dim delParamFruitId As SqlParameter = New SqlParameter("@fruitid", SqlDbType.Int)
        delParamFruitId.SourceColumn = "Id"
        fruitDataAdapter.DeleteCommand.Parameters.Add(delParamFruitId)

        'Finally, set the datasource of the grid
        FruitGridView.DataSource = fruitDataTable

    End Sub

    ''' <summary>
    ''' Sets the appropriate properties on the grid columns so they bind to
    ''' our data. This could be done in the designer instead but it is done here
    ''' for instructional purposes.
    ''' The Grid columns were intentionally done in the designer to demonstrate how to do that,
    ''' then demonsrate how to get a reference to a specific column in code.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setColumnProperties()

        Dim fruitNameColumn As DataGridViewTextBoxColumn = DirectCast(FruitGridView.Columns("colFruitName"), DataGridViewTextBoxColumn)
        fruitNameColumn.DataPropertyName = "FruitName"

        Dim fruitColorColumn As DataGridViewTextBoxColumn = DirectCast(FruitGridView.Columns("colFruitColor"), DataGridViewTextBoxColumn)
        fruitColorColumn.DataPropertyName = "FruitColor"

        Dim fruitGrowsOnColumn As DataGridViewComboBoxColumn = DirectCast(FruitGridView.Columns("colFruitGrowsOn"), DataGridViewComboBoxColumn)
        fruitGrowsOnColumn.DataPropertyName = "FruitGrowsOn"

        Dim fruitIsYummyColumn As DataGridViewCheckBoxColumn = DirectCast(FruitGridView.Columns("colFruitIsYummy"), DataGridViewCheckBoxColumn)
        fruitIsYummyColumn.DataPropertyName = "FruitIsYummy"

    End Sub

    Private Function getConnectionString() As String

        'An often overlooked gem, SqlConnectionStringBuilder simplifies creating a connection
        Dim csb As SqlConnectionStringBuilder = New SqlConnectionStringBuilder()
        csb.DataSource = "(localdb)\v11.0"  'This is the lightweight sql server that comes with Visual Studio
        csb.InitialCatalog = "Fruit"
        csb.IntegratedSecurity = True
        Return csb.ConnectionString

    End Function

    ''' <summary>
    ''' Clean up some resources.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        fruitDataAdapter.SelectCommand.Dispose()
        fruitDataAdapter.UpdateCommand.Dispose()
        fruitDataAdapter.Dispose()
    End Sub

    ''' <summary>
    ''' Updates the database with any changes that have been made. These could include any combination
    ''' of inserts, updates and deletes.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        fruitDataAdapter.Update(fruitDataTable)
        Await ShowMessage()
    End Sub

    ''' <summary>
    ''' Show success message without blocking the UI via Async
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Async Function ShowMessage() As Task(Of Boolean)

        lblUpdate.Visible = True
        Await Task.Delay(2000)
        lblUpdate.Visible = False
        Return True

    End Function
End Class
