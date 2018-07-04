$(() => {
    const memberId = $("table").data('member-id');
    const endeavorsHub = $.connection.endeavorsHub;

    $.connection.hub.start().done(() => {
        endeavorsHub.server.getAndSendEndeavors();
    })

    $("#submit").on('click', function () {
        const title = $("#title").val();
        endeavorsHub.server.newEndeavor(title);
        $("#title").val('');
    });

    endeavorsHub.client.renderEndeavors = endeavors => {
        console.log(endeavors);
        $("table tr:gt(0)").remove();
        endeavors.forEach(e => {
            let buttonHtml;
            console.log(e.HandledBy);
            
            if (e.HandledBy && e.HandledBy === memberId) {
                buttonHtml = `<button data-member-id=${e.Id} class='btn btn-success done'>I'm done!</button>`;
            } else if (e.Name) {
                buttonHtml = `<button class='btn btn-warning' disabled>${e.Name} is doing this</button>`;
            } else {
                buttonHtml = `<button data-member-id=${e.Id} class='btn btn-info doing'>I'm doing this one!</button>`;
            }
            $("table").append(`<tr><td>${e.Endeavor1}</td><td>${buttonHtml}</td></tr>`);
        })
    }

    $("table").on('click', '.done', function () {
        const id = $(this).data('member-id');
        endeavorsHub.server.setDone(id);
    });

    $("table").on('click', '.doing', function () {
        const id = $(this).data('member-id');
        endeavorsHub.server.setDoing(id);
    });
});