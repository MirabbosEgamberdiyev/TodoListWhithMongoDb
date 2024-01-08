// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
< !-- ... (old code) ... -->

    <><script>
        function deleteTodo(id) {}
        if (confirm('Are you sure you want to delete this todo?')) {$.post('/Home/Delete', { id: id }, function(data) {
            // Handle the response if needed
            // Reload or update the UI
            location.reload(); // Refresh the page
        })};
        }
        }

        function populateForm(id) {$.get('/Home/PopulateForm', { id: id }, function(data) {
            // Handle the response if needed
            // Populate the form with the received data
            // Example: Assuming you have an input field with id="todoId"
            $('#todoId').val(data.id);
            $('#todoName').val(data.name);
        })};
        }
    </script>< /></>!-- ... (old code) ... -->
