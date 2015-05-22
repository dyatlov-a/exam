var $ = jQuery = require('../libs/jquery/jquery-1.11.3.js'),
    addTask = require('./_addTask.js'),
    actived = require('./_activedTask.js');

require('../libs/bootstrap/bootstrap.js');

(function Init() {
    addTask('#taskTopic', '#taskText', '#todolist', '#addTask');
    actived('#todolist');
})();