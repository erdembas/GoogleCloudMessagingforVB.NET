@ModelType IEnumerable(Of GCMServer.Kullanici)
@Code
    ViewData("Title") = "Home Page"
End Code

<script src="~/Scripts/jquery-1.7.1.min.js"></script>
<script src="~/Content/SimpleModal/simple-modal.js"></script>
<link href="~/Content/SimpleModal/simplemodal.css" rel="stylesheet" />
@section featured
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h2>VB.NET ile Servera kayıt olmuş telefonlara istediğiniz mesajları gönderebilirsiniz... </h2>
            </hgroup>

        </div>
    </section>
End Section

<h3>Kayıtlı Cihazlar</h3>
<table class="table1">
    <thead>
        <tr>
            <th>RegID</th>
            <th>E-Mail</th>
            <th>Kayıt Tarih</th>
            <th>İşlemler</th>
        </tr>
    </thead>
    <tbody>
        @For Each item In Model
            @<tr style="width:100%">
                <td style="border-right:1px dashed"><a href="javascript:RegIDGoster('@item.GCM_Reg_ID')">Göster</a></td>
                <td style="border-right:1px dashed">@item.EMail</td>
                <td style="border-right:1px dashed">@FormatDateTime(item.Tarih,DateFormat.ShortDate)</td>
                <td><a href="javascript:MesajGonder('@item.GCM_Reg_ID')">Mesaj Gönder</a></td>
            </tr>
        Next
    </tbody>


</table>




<script>
    function RegIDGoster(ID) {
        $.fn.SimpleModal({
            model: 'modal',
            title: 'Cihaz RegID',
            contents: ID
        }).addButton('Kapat', 'btn').showModal();
    }

    function MesajGonder(ID) {
        $.fn.SimpleModal({
            model: 'modal',
            width: '350',
            title: 'Mesajınız',
            contents: '<textarea id="Mesaj" style="width:305px"></textarea>'
        }).addButton('Gönder', 'btn primary', function () {
            $.ajax({
                type: 'POST',
                data: { RegID: ID, sCommand: $("#Mesaj").val() },
                url: '/Home/KomutGonder',
                success: function (r) {
                    alert(r);
                }
            })

            this.hideModal();
    
        }).addButton('Kapat', 'btn').showModal();
    }
</script>
