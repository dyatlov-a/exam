var $ = jQuery = require('../libs/jquery/jquery-1.11.3.js');

module.exports = function(topicField, textField, todolist, addBtn) {
    $(addBtn).click(function() {
        var topicVal = $(topicField).val(),
            textVal = $(textField).val();

        if (!topicVal.trim() && !textVal.trim()) {
            alert('Заполните поля название и описание задания');
        } else {
            $.post('/Todolist/Add',
            {
                topic: topicVal,
                text: textVal
            }).done(function addSuccess(data) {
                $(todolist).prepend(data);
                $(topicField).val("");
                $(textField).val("");
            });
        }
    });
};