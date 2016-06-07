$.ajax({
	url: "/api/notes/notifications",
	method: "GET",
	success: function (data) {
		notifications = data;
		for (var i = 0; i < data.length; i++) {
			var el = toastr.success(data[i].Text, "Notification", {
				"closeButton": false,
				"debug": false,
				"newestOnTop": true,
				"progressBar": false,
				"positionClass": "toast-top-right",
				"preventDuplicates": false,
				"onclick": null,
				"showDuration": "300",
				"hideDuration": "1000",
				"timeOut": "0",
				"extendedTimeOut": "0",
				"showEasing": "swing",
				"hideEasing": "linear",
				"showMethod": "fadeIn",
				"hideMethod": "fadeOut"
			});
		}
	}
});