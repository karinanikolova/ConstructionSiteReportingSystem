document.addEventListener("DOMContentLoaded", function () {
    const popoverTriggerList = document.querySelectorAll('[data-bs-toggle="popover"]');
    const popoverList = [...popoverTriggerList].map(popoverTriggerEl => new bootstrap.Popover(popoverTriggerEl));

    const plusBtnList = document.querySelectorAll('button[data-btn-for]');

    for (const btn of plusBtnList) {
        btn.addEventListener('click', btnEventHandler);
    }

    function btnEventHandler(e) {
        const proceedBtn = e.target.closest('#workForm').querySelector('#addEditWork a');
        const proceedMsgPar = e.target.closest('#workForm').querySelector('#addEditWork p');

        if (e.target.dataset.btnFor === 'workType') {
            proceedBtn.href = '/Suggest/WorkType';
            proceedMsgPar.textContent = 'You are about to be redirected to another page. All filled-in data will be lost. Do you wish to proceed and suggest a new construction and assembly work type?';

        } else if (e.target.dataset.btnFor === 'stage') {
            proceedBtn.href = '/Suggest/Stage';
            proceedMsgPar.textContent = 'You are about to be redirected to another page. All filled-in data will be lost. Do you wish to proceed and suggest a new construction stage?';

        } else if (e.target.dataset.btnFor === 'contractor') {
            proceedBtn.href = '/Suggest/Contractor';
            proceedMsgPar.textContent = 'You are about to be redirected to another page. All filled-in data will be lost. Do you wish to proceed and suggest a new contractor?';

        } else if (e.target.dataset.btnFor === 'unit') {
            proceedBtn.href = '/Suggest/Unit';
            proceedMsgPar.textContent = 'You are about to be redirected to another page. All filled-in data will be lost. Do you wish to proceed and suggest a new measurement unit?';
        }
    }
});

let message = (function () {
    if (typeof toastr === "undefined") {
        return;
    }

    toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": false,
        "progressBar": false,
        "positionClass": "toast-bottom-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    };

    let showInfo = function (message) {
        toastr["info"](message);
    };

    return { showInfo };
})();