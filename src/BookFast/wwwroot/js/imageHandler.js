var BookFast;
(function (module) {
    var ImageHandler = (function () {
        function ImageHandler() {
        }

        ImageHandler.prototype.initialize = function (imageHiddenFieldsContainerId, imageListContainerId) {
            var fieldContainer = $('#' + imageHiddenFieldsContainerId);
            var imageListContainer = $('#' + imageListContainerId);

            $('.btn-remove-image').click(function () {
                var imageUrl = $(this).data('image');

                $('[value="' + imageUrl + '"]').remove();
                $('[src="' + imageUrl + '"]').parent().remove();
            });

            $('.btn-add-image').click(function () {
                var id = $('#Id').val();
                $.getJSON('/api/facilities/' + id + '/image-token', { originalFileName: 'test.jpg' })
                .done(function (result) {
                    alert(result.url);
                })
                .fail(function () {
                    alert('Error getting SAS token');
                });
            });
        };

        return ImageHandler;
    })();
    module.ImageHandler = ImageHandler;
})(BookFast || (BookFast = {}));