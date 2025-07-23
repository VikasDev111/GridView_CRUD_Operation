<%@ Page Language="C#" AutoEventWireup="true" CodeFile="gridview_crud.aspx.cs" Inherits="gridview_crud" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="UTF-8" />
<meta name="viewport" content="width=device-width,initial-scale=1.0" />
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
    .container {
        max-width: 900px;
    }

    .card-header {
        font-weight: bold;
        font-size: 1.2rem;
    }

    .form-control {
        box-shadow: none;
    }

    .btn {
        transition: 0.3s ease;
    }

    .btn:hover {
        opacity: 0.9;
    }
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container mt-4">

    <!-- Search Section -->
    <div class="row mb-3">
        <div class="col-md-4">
            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" Placeholder="Search by Name" />
        </div>
        <div class="col-md-2">
            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary w-100" OnClick="btnSearch_Click" />
        </div>
    </div>

    <!-- Insert Section -->
    <div class="card mb-4">
        <div class="card-header text-center bg-success text-white">
            Add New Student
        </div>
        <div class="card-body">
            <div class="row g-2">
                <div class="col-md-4">
                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control" Placeholder="Enter Name" />
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="txtAge" runat="server" CssClass="form-control" Placeholder="Enter Age" />
                </div>
                <div class="col-md-4">
                    <asp:Button ID="btnInsert" runat="server" Text="Add Student" CssClass="btn btn-success w-100" OnClick="btnInsert_Click" />
                </div>
            </div>
        </div>
    </div>

    <!-- GridView Section -->
    <div class="table-responsive">
        <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover table-striped"
            AutoGenerateColumns="False" DataKeyNames="Id"
            OnRowEditing="GridView1_RowEditing"
            OnRowUpdating="GridView1_RowUpdating"
            OnRowCancelingEdit="GridView1_RowCancelingEdit"
            OnRowDeleting="GridView1_RowDeleting">

            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Age" HeaderText="Age" />
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    </div>

</div>

    <!-- Modal popup  -->
  <%--  <asp:Button ID="btnShowModal" runat="server" Text="Add Student" CssClass="btn btn-primary"
        OnClientClick="$('#myModal').modal('show'); return false;" />
    <!-- Modal -->
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">
                        Add Student</h5>
                    <button type="button" class="close" data-dismiss="modal">
                        &times;</button>
                </div>
                <div class="modal-body">
                    <asp:TextBox ID="txtModalName" runat="server" CssClass="form-control" Placeholder="Enter Name" />
                    <asp:TextBox ID="txtModalAge" runat="server" CssClass="form-control" Placeholder="Enter Age" />
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnModalInsert" runat="server" Text="Save" CssClass="btn btn-success"
                        OnClick="btnModalInsert_Click" />
                </div>
            </div>
        </div>
    </div>--%>
    <!-- modal popup end -->
    </form>
</body>
</html>
