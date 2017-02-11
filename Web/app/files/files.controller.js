(function() {
    "use strict";

    angular
        .module("app")
        .controller("FilesController", controller);

    controller.$inject = [
        "$scope",
        "$q",
        "webApiService"
    ];

    function controller(
        $scope,
        $q,
        webApiService
    ) {

        $scope.value = "Files";
        //$scope.folders = [];
        $scope.files = [];
        $scope.foldersTree = null;
        $scope.selectedFolder = null;

        $scope.selectFolder = selectFolder;

        ////////////

        var folders = [];

        function selectFolder(item) {
            if ($scope.selectedFolder == item)
                $scope.selectedFolder = null;
            else
                $scope.selectedFolder = item;
        };

        function getFiles() {
            return webApiService.get("files", "get")
                .then(function(data) {
                    $scope.files = data;
                });
        };

        function getFolders() {
            return webApiService.get("folders", "get")
                .then(function(data) {
                    folders = data;
                });
        };

        function prepare() {
            $scope.foldersTree = folders;
            _.forEach($scope.foldersTree, function (f) {
                if (!f.parentId)
                    return;
                var parent = _.find($scope.foldersTree, { id: f.parentId });
                if (!parent.childrens)
                    parent.childrens = [];
                parent.childrens.push(f);
            });
            $scope.foldersTree = _.filter($scope.foldersTree, { parentId: null });
        };

        function refresh() {
            $q.all([
                    getFiles(),
                    getFolders()
                ])
                .then(prepare);
        };

        refresh();
    };
})();