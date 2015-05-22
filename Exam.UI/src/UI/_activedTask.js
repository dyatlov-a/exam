var $ = jQuery = require('../libs/jquery/jquery-1.11.3.js');

module.exports = function(taskList) {
    $(taskList).click(function (e) {
        var elem = $(e.target);

        if (elem.is(':button')) {
            var url = $(elem).attr('data-url');

            $.ajax({
                type: "Get",
                url: url,
                success: function onSuccess() {
                    $(e.target).parent().remove();
                }
            });
        }
    });
};