var BookFast;
(function (module) {
    var ImageHandler = (function () {
        function ImageHandler() {
        }

        ImageHandler.prototype.initialize = function (tokenEndpoint, imageHiddenFieldsContainerId, imageListContainerId) {
            var tokenEndpoint = tokenEndpoint;
            var fieldContainer = $('#' + imageHiddenFieldsContainerId);
            var imageListContainer = $('#' + imageListContainerId);

            var maxBlockSize = 256 * 1024;
            var blockSize = 0;
            var numberOfBlocks = 0;
            var currentFilePointer = 0;
            var totalBytesRemaining = 0;
            var selectedFile;

            var blockIds = new Array();
            var blockIdPrefix = "block-";
            var bytesUploaded = 0;
            var submitUri;
                        
            $('.btn-remove-image').click(function () {
                var imageUrl = $(this).data('image');

                $('[value="' + imageUrl + '"]').remove();
                $('[src="' + imageUrl + '"]').parent().remove();
            });

            $('#file').change(function (e) {
                var files = e.target.files;

                selectedFile = files[0];
                $("#fileName").text(selectedFile.name);
                $("#fileSize").text(selectedFile.size);
                $("#fileType").text(selectedFile.type);
                
                var fileSize = selectedFile.size;
                if (fileSize < maxBlockSize) {
                    blockSize = fileSize;
                }
                else {
                    blockSize = maxBlockSize;
                }
                console.log("block size = " + blockSize);

                totalBytesRemaining = fileSize;
                if (fileSize % blockSize == 0) {
                    numberOfBlocks = fileSize / blockSize;
                } else {
                    numberOfBlocks = parseInt(fileSize / blockSize, 10) + 1;
                }
                console.log("total blocks = " + numberOfBlocks);
            });

            $('.btn-add-image').click(function () {
                var id = $('#Id').val();
                $.getJSON('/api/' + tokenEndpoint + '/' + id + '/image-token', { originalFileName: selectedFile.name })
                .done(function (result) {
                    submitUri = result.url;
                    upload();
                })
                .fail(function () {
                    alert('Error getting SAS token');
                });
            });

            function upload() {
                var reader = new FileReader();

                reader.onloadend = function (evt) {
                    if (evt.target.readyState == FileReader.DONE) {
                        var uri = submitUri + '&comp=block&blockid=' + blockIds[blockIds.length - 1];
                        var requestData = new Uint8Array(evt.target.result);
                        $.ajax({
                            url: uri,
                            type: "PUT",
                            data: requestData,
                            processData: false,
                            beforeSend: function (xhr) {
                                xhr.setRequestHeader('x-ms-blob-type', 'BlockBlob');
                                xhr.setRequestHeader('Content-Length', requestData.length);
                            },
                            success: function (data, status) {
                                console.log(data);
                                console.log(status);
                                bytesUploaded += requestData.length;
                                var percentComplete = ((parseFloat(bytesUploaded) / parseFloat(selectedFile.size)) * 100).toFixed(2);
                                $("#fileUploadProgress").text(percentComplete + " %");
                                uploadFileInBlocks(reader);
                            },
                            error: function (xhr, desc, err) {
                                console.log(desc);
                                console.log(err);
                            }
                        });
                    }
                };

                uploadFileInBlocks(reader);
            }

            function uploadFileInBlocks(reader) {
                if (totalBytesRemaining > 0) {
                    console.log("current file pointer = " + currentFilePointer + " bytes read = " + blockSize);
                    var fileContent = selectedFile.slice(currentFilePointer, currentFilePointer + blockSize);
                    var blockId = blockIdPrefix + pad(blockIds.length, 6);
                    console.log("block id = " + blockId);
                    blockIds.push(btoa(blockId));
                    reader.readAsArrayBuffer(fileContent);
                    currentFilePointer += blockSize;
                    totalBytesRemaining -= blockSize;
                    if (totalBytesRemaining < blockSize) {
                        blockSize = totalBytesRemaining;
                    }
                } else {
                    commitBlockList();
                }
            }

            function commitBlockList() {
                var uri = submitUri + '&comp=blocklist';
                console.log(uri);
                var requestBody = '<?xml version="1.0" encoding="utf-8"?><BlockList>';
                for (var i = 0; i < blockIds.length; i++) {
                    requestBody += '<Latest>' + blockIds[i] + '</Latest>';
                }
                requestBody += '</BlockList>';
                console.log(requestBody);
                $.ajax({
                    url: uri,
                    type: "PUT",
                    data: requestBody,
                    beforeSend: function (xhr) {
                        xhr.setRequestHeader('x-ms-blob-content-type', selectedFile.type);
                        xhr.setRequestHeader('Content-Length', requestBody.length);
                    },
                    success: function (data, status) {
                        console.log(data);
                        console.log(status);
                    },
                    error: function (xhr, desc, err) {
                        console.log(desc);
                        console.log(err);
                    }
                });

            }

            function pad(number, length) {
                var str = '' + number;
                while (str.length < length) {
                    str = '0' + str;
                }
                return str;
            }

        };

        return ImageHandler;
    })();
    module.ImageHandler = ImageHandler;
})(BookFast || (BookFast = {}));