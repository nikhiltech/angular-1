(function() {
    "use strict";

    angular
        .module("app")
        .controller("MovieController", controller);

    controller.$inject = [
        "$scope",
        "$http",
        "webApiService"
    ];

    function controller(
        $scope,
        $http,
        webApiService
    ) {

        $scope.value = "Movie";
        $scope.webApi = webApiService.confirm;
        $scope.movies = [];

        ////////////

        function refresh() {
            webApiService.get("movies", "get")
                .then(function(data) {
                    $scope.movies = data;
                });
        };

        refresh();
    };
})();