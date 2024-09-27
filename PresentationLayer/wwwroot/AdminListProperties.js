
            $(document).ready(function () {
                // Add Property Form Submission
                $('#addPropertyForm').submit(function (e) {
                    e.preventDefault();
                    $.ajax({
                        url: this.action,
                        type: this.method,
                        data: $(this).serialize(),
                        success: function (result) {
                            $('#addPropertyModal').modal('hide');
                            window.location.reload();
                        },
                        error: function (xhr, status, error) {
                            alert('An error occurred while saving the property. Please try again.');
                            console.error(error);
                        }
                    });
                });

                    // When the edit button is clicked
                    $('#editPropertyModal').on('show.bs.modal', function (event) {
                        var button = $(event.relatedTarget); // Button that triggered the modal
                        var propertyId = button.data('ID'); // Extract property ID from data-* attribute

                        // AJAX call to get the property details from the controller
                        $.ajax({
                            url: '/Admin/EditProperty?'+propertyId , // Controller action to fetch property details
                            type: 'GET',
                            data: { id: propertyId }, // Send the property ID
                            success: function (response) {
                                // Populate the modal fields with the retrieved data
                                $('#editPropertyId').val(response.id);
                                $('#editPropertyName').val(response.name);
                                $('#editPropertyAddress').val(response.location);
                                $('#editPropertyDescription').val(response.description);
                                $('#editPropertyArea').val(response.area);
                                $('#editPropertyPrice').val(response.price);
                                $('#editPropertyType').val(response.type);
                            },
                            error: function (xhr, status, error) {
                                // Handle errors if the property could not be retrieved
                                alert('Error retrieving property details.');
                                console.error(error);
                            }
                        });
                    });

                // Edit Property Modal Population
                $('#editPropertyModal').on('show.bs.modal', function (event) {
                    var button = $(event.relatedTarget);
                    var id = button.data('id');
                    var name = button.data('name');
                    var address = button.data('address');
                    var description = button.data('description');
                    var area = button.data('area');
                    var price = button.data('price');
                    var type = button.data('type');

                    var modal = $(this);
                    modal.find('#editPropertyId').val(id);
                    modal.find('#editPropertyName').val(name);
                    modal.find('#editPropertyAddress').val(address);
                    modal.find('#editPropertyDescription').val(description);
                    modal.find('#editPropertyArea').val(area);
                    modal.find('#editPropertyPrice').val(price);
                    modal.find('#editPropertyType').val(type);
                });

                // Delete Property
                $('#deletePropertyModal').on('show.bs.modal', function (event) {
                    var button = $(event.relatedTarget);
                    var id = button.data('id');
                    var modal = $(this);
                    modal.find('#deletePropertyId').val(id);
                });

                $('#confirmDeleteButton').click(function () {
                    var id = $('#deletePropertyId').val();
                    $.ajax({
                        url: '@Url.Action("DeleteProperty", "Admin")',
                        type: 'POST',
                        data: { id: id },
                        success: function (result) {
                            $('#deletePropertyModal').modal('hide');
                            window.location.reload();
                        },
                        error: function (xhr, status, error) {
                            alert('An error occurred while deleting the property. Please try again.');
                            console.error(error);
                        }
                    });
                });
            });
