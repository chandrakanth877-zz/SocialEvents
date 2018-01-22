var GigsController = function (attendanceService) {

    var button;

    var init = function (container) {
        $(container).on("click", ".js-toggle-attendances", toggleAttendances)
    };

    var toggleAttendances = function (e) {
        button = $(e.target);
        var data = button.attr('data-gig-id');
        if (button.hasClass("btn-default")) {
            attendanceService.createAttendance(data, done, fail);
        } else {
            attendanceService.deleteAttendance(data, done, fail);
        }

    };

    var fail = function () {
        alert("error");
    }

    var done = function () {
        var buttonText = (button.text === "Going") ? "Going?" : "Going";
        button.toggleClass("btn-info").toggleClass("btn-default").text(buttonText);
    }

    return {
        init: init
    }
}(AttendanceService);
