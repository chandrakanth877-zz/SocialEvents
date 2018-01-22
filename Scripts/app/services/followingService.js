var FollowingService = function() {
    var createFollowing = function(data, done, fail) {
        $.post("/api/followings", { "FolloweeId": data })
            .done(done)
            .fail(fail);
    }
    var deleteFollowing = function (data, done, fail) {
        $.ajax({
                url: "/api/followings/"+data,
                method: "DELETE"
            }) 
            .done(done)
            .fail(fail);
    }

    return {
        createFollowing: createFollowing,
        deleteFollowing: deleteFollowing
    }
}();