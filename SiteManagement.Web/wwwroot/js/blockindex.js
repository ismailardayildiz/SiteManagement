$(document).ready(function () {
    const placeholder = $('#modalPlaceHolder');

    // Ekleme Modalını Aç
    $(document).on('click', '#btnAddBlock', function () {
        $.get('/Admin/Block/Add').done(function (data) {
            placeholder.html(data);
            placeholder.find('.modal').modal('show');
        });
    });

    // Güncelleme Modalını Aç
    $(document).on('click', '.update-block', function () {
        const id = $(this).data('id');
        $.get('/Admin/Block/Update/' + id).done(function (data) {
            placeholder.html(data);
            placeholder.find('.modal').modal('show');
        });
    });

    // Kaydet/Güncelle Buton Kontrolü
    $(document).on('click', '#btnSaveBlock, #btnUpdateBlock', function (e) {
        e.preventDefault();
        const form = $(this).closest('form');
        const url = (this.id === 'btnSaveBlock') ? '/Admin/Block/Add' : '/Admin/Block/Update';

        $.post(url, form.serialize()).done(function (data) {
            if (data.success) {
                location.reload();
            } else {
                placeholder.html(data);
                placeholder.find('.modal').modal('show');
            }
        });
    });
});

// Silme İşlemi
$(document).on('click', '.delete-block', function () {
    const id = $(this).data('id');
    if (confirm("Bu bloğu silmek istediğinize emin misiniz?")) {
        $.post('/Admin/Block/Delete/' + id).done(function (data) {
            if (data.success) {
                location.reload();
            } else {
                alert(data.message);
            }
        });
    }
});