<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<Dominion.Web.ViewModels.NewGameViewModel>" MasterPageFile="~/Views/Shared/site.Master" %>
<%@ Import Namespace="Dominion.Web.Controllers" %>
<asp:Content runat="server" ID="Content" ContentPlaceHolderID="TitleContent"></asp:Content>
<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="HeadContent">
<script type="text/javascript">
    $(document).ready( function() {
        $('#numberOfPlayers')
            .change( function(event) {
                populateNames(event.target.value);
            });
        $('#submitbutton').attr('disabled', true);
    });

    function populateNames(numberOfPlayers) {
        var names = "Player1";
        for(var i = 2; i <= numberOfPlayers; i++)
            names += ", Player" + i
        $('#Names')
            .val(names);
    }

    function checkIfSubmitAllowed() {
        //currently only checking that there are 10 cards picked.
        //should update this to check the player count and names.
        var allCardCheckboxes = $(".someCard");
        var selectedCount = 0;
        for (var iCheckbox = 0; iCheckbox < allCardCheckboxes.length; iCheckbox++) {
            var checkBox = allCardCheckboxes[iCheckbox];
            if (checkBox.checked)
                selectedCount++;
        }
        $("#submitbutton").attr("disabled", selectedCount != 10);
    }
</script>
</asp:Content>
<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="MainContent">     
    <form action="NewGame" method="post">       
        <%= Html.DropDownList("numberOfPlayers", 
            Enumerable.Range(1,6).Select(x => new SelectListItem { Text = x.ToString(), Value = x.ToString()}),
            "Number of Players"                    
            ) %>
        Player names: <%= Html.TextBox("Names", "", new { style="width:250px"}) %>
        <br />
        <br />
        <%= Html.EditorFor(x => x.UseProsperty) %> Use Prosperity cards (Platinum & Colony)
        <br />
        <br />
        <% foreach (var cardName in Model.CardsToChooseFrom.OrderBy(c => c))
           {%>
           <input type="checkbox" name="chosenCards" class="someCard" value="<%=cardName%>" onclick="checkIfSubmitAllowed()" <%= Model.ChosenCards.Contains(cardName) ? "checked=checked" : "" %> />
           <%= cardName%>
           <br />
        <% } %>
        <%= Html.SubmitButton("submitbutton", "New Game") %>
    </form>
</asp:Content>
