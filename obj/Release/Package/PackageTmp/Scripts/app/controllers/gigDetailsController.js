var GigDetailsController = function(followingService) {
    var button;

    var init = function() {
        $('.js-toggle-follow').click(toggleFollowing);

    }

    var toggleFollowing = function(e) {
        button = $(e.target);
        var data = button.attr('data-user-id');
        console.log(data);
        if (button.hasClass("btn-default")) {
            followingService.createFollowing(data, done, fail);
        } else {
            followingService.deleteFollowing(data, done, fail);
        }


    };

    var fail = function() {
        alert("error ");
    }

    var done = function() {
        var buttonText = (button.text === "Follow") ? "Following" : "Follow";
        button.toggleClass("btn-info").toggleClass("btn-default").text(buttonText);
    }

    return {
        init: init
    }
}(FollowingService);