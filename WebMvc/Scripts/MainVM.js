var pageVM = function (data) {

    var vm = this;
    vm.saving = ko.observable(false);

    // Form atts
    vm.FirstName = ko.observable(data.pfName).extend({
        required: true,
        minLength: 3, maxLength: 12
    });
    vm.FirstName.subscribe(function (v) { vm.onFieldUpdatedHandler(v) });

    vm.LastName = ko.observable(data.plName).extend({
        required: true,
        minLength: 3, maxLength: 12
    });
    vm.LastName.subscribe(function (v) { vm.onFieldUpdatedHandler(v) });

    vm.Age = ko.observable(data.pAge).extend({
        required: true,
        number: { params: true, message: "custom number message!" }
    }
    );
    vm.Age.subscribe(function (v) { vm.onFieldUpdatedHandler(v) });

    vm.countries = ko.observableArray(data.cs);

    vm.Country = ko.observable(data.pCountry);
    vm.Country.subscribe(function (v) { vm.onFieldUpdatedHandler(v) });

    // Operations
    vm.saveState = function () {
        console.log("Checking for other errors in the model.");

        if (vm.errors().length === 0) {
            console.log("No errors - Checking for an in-progress save operation.");
            if (vm.saving() == true) {
                console.log("Double Saving detected ... aborting.");
                return;
            }

            vm.saving(true);
            try {
                console.log(ko.toJS(vm));
                $.ajax({
                    url: "api1/api/v1/person/person",
                    type: "PUT",
                    data: ko.toJSON(vm, function (k, v) {
                        switch (k) {
                            case "errors":
                            case "countries":
                            case "saving":
                            case "onFieldUpdatedHandler":
                                return undefined;
                            default:
                                return v;
                        }
                    }),
                    dataType: "json",
                    contentType: "application/json"
                }).done(function (res) {
                    alert("Saved! res=" + ko.toJS(res));
                    vm.FirstName(res.FirstName);
                    vm.LastName(res.LastName);
                    vm.Country(res.Country);
                    vm.Age(res.Age);
                }).fail(function (jqXHR, textStatus) {
                    alert("Error Handler! res=" + textStatus);
                });
            }
            catch (e) { alert("An error occured while attempting to save data."); }
            vm.saving(false);
        }
        else {
            console.log("Errors found. Save aborted");
        }
    };

    vm.onFieldUpdatedHandler = function (v) {
        if (vm.errors().length == 0)
            vm.saveState();
    };

    vm.errors = ko.validation.group(vm);
};

