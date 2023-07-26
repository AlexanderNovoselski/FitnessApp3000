// Create a connection to the SignalR hub
var connection = new signalR.HubConnectionBuilder().withUrl("/DietHub").build();

connection.on("ReceiveMessage", function (diet) {
    // Update the view with the new diet details
    var li = document.createElement("li");
    li.textContent = "New diet added: " + diet.name;
    document.getElementById("messagesList").appendChild(li);
});

// Define the RemoveDiet event to handle the removed diet
connection.on("RemoveDiet", function (dietId) {
    // Fetch the current page's content with AJAX to update the view
    var currentPage = $('.pagination .page-item.active .page-link').text();
    var sortingType = $('#SortingType').val();
    fetchDietsAndHandlePagination(currentPage, sortingType);
});

// Function to fetch diets for the current page and handle pagination
function fetchDietsAndHandlePagination(page, sortingType) {
    var url = `/Diet/GetAll?page=${page}&sortingType=${sortingType}`;
    $.ajax({
        url: url,
        type: 'GET',
        success: function (data) {
            $('#dietsContainer').html($(data).find('#dietsContainer').html());
            handlePagination();
        },
        error: function (xhr, status, error) {
            console.error(error);
        }
    });
}


// Start the SignalR connection
connection.start().then(function () {
    // Connection started successfully
    console.log("SignalR connection started.");
}).catch(function (err) {
    // Connection failed
    console.error(err.toString());
});
function handlePagination() {
    var totalPages = parseInt($('#totalPages').val());
    if (currentPage <= 0) {
        currentPage = 1;
    } else if (currentPage > totalPages) {
        currentPage = totalPages;
    }

    $('.pagination li').removeClass('active');
    $(`.pagination li a[data-page="${currentPage}"]`).parent().addClass('active');

    // Hide or show previous/next buttons based on current page
    if (currentPage === 1) {
        $('.pagination li:first-child').addClass('disabled');
    } else {
        $('.pagination li:first-child').removeClass('disabled');
    }

    if (currentPage === totalPages) {
        $('.pagination li:last-child').addClass('disabled');
    } else {
        $('.pagination li:last-child').removeClass('disabled');
    }

    // Hide the last page if it's empty
    var lastPageIsEmpty = $('#dietsContainer .card').length === 0;
    if (lastPageIsEmpty && currentPage === totalPages) {
        $('.pagination li:last-child').hide();
    } else {
        $('.pagination li:last-child').show();
    }
}