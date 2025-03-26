function init() {
    /* On first app launch, user lands on Part Search page */
    if (sessionStorage.getItem("MapicsHistory") == null) {
        var part_tab = document.getElementById("bom-lookup-tab");
        part_tab.style.setProperty("background-color", "#f0f7fa");
        //part_tab.style.setProperty("border", "1px solid #0078b3");
        var json_object = { "page_title": "bom-lookup-tab", "search_phrase": '', "search_by": '' };
        var json_string = JSON.stringify(json_object);
        sessionStorage.setItem("MapicsHistory", json_string);
        return null;
    }
    if (sessionStorage.getItem("MapicsHistory").search_by === undefined || sessionStorage.getItem("MapicsHistory").search_by == null || sessionStorage.getItem("MapicsHistory").search_by == '') {
        select_first_radio_button();
    }
    /* Every page load executes these commands. Each page load clears inputs from last search. Store in Session Storage */
    set_color_from_cookie();
    set_search_bar_text();
    set_radio_button();

    var page_title = document.getElementById("page-title").innerHTML;
    var dyn_page_title = document.getElementById("dynamic-page-title").innerHTML;
    if (page_title == "po-lookup-tab" ) {
        var po_form = document.getElementById("po-search-form");
        
        if ( dyn_page_title == "PO Search" || dyn_page_title.includes("PO Number") || dyn_page_title.includes("Part Number") ) {
            po_form.style.setProperty("margin-right", "5vw");
        }
        if (dyn_page_title.includes("Vendor ID") || dyn_page_title.includes("Vendor Name") ){
            po_form.style.setProperty("margin-right", "19vw");
        }
    }

}

/* Every time user navigates to a new tab, the last search gets cleared */
function on_navigate_to_part() {
    var json_object = { "page_title": "part-lookup-tab", "search_phrase": '', "search_by": '' };
    var json_string = JSON.stringify(json_object);
    sessionStorage.setItem("MapicsHistory", json_string);
}
function on_navigate_to_po() {
    var json_object = { "page_title": "po-lookup-tab", "search_phrase": '', "search_by": '' };
    var json_string = JSON.stringify(json_object);
    sessionStorage.setItem("MapicsHistory", json_string);
}
function on_navigate_to_bom() {
    var json_object = { "page_title": "bom-lookup-tab", "search_phrase": '', "search_by": '' };
    var json_string = JSON.stringify(json_object);
    sessionStorage.setItem("MapicsHistory", json_string);
}
function set_color_from_cookie() {
    var json_string = sessionStorage.getItem("MapicsHistory");
    var json_obj = JSON.parse(json_string);
    var page_title_id = json_obj.page_title;
    var tab_elem = document.getElementById(page_title_id);
    tab_elem.style.setProperty("background-color", "#f0f7fa");
    //tab_elem.style.setProperty("border", "1px solid #0078b3");

}
function select_first_radio_button() {
    var radio_buttons = document.getElementsByClassName("radio_btn");
    radio_buttons[0].checked = true;
}
/* Every time search is executed, save the parameters from the search menu */
function save_search() {
    var page_title = document.getElementById("page-title").innerHTML;
    var search_phrase = document.getElementById("search_phrase").value;
    if (document.querySelector('input[name="search_field"]:checked') != null)
        var search_by = document.querySelector('input[name="search_field"]:checked').value
    if (page_title == null) page_title = '';
    if (search_phrase == null) search_phrase = '';
    if (search_by == null) search_by = '';
    console.log(page_title + " - " + search_phrase + " - " + search_by);
    var json_object = { "page_title": page_title, "search_phrase": search_phrase, "search_by": search_by };
    var json_string = JSON.stringify(json_object);
    sessionStorage.setItem("MapicsHistory", json_string);
}

/* Put the last searched text into the search box */
function set_search_bar_text() {
    var json_string = sessionStorage.getItem("MapicsHistory");
    if (json_string == null) {
        return null;
    }
    var json_obj = JSON.parse(json_string);
    var search_phrase = json_obj.search_phrase;
    if (search_phrase == null || search_phrase == '') {
        return null;
    }
    var cookie_page_title = json_obj.page_title;
    var html_page_title = document.getElementById("page-title").innerHTML;
    if (cookie_page_title == html_page_title) {
        var mVal = json_obj.search_phrase;
        document.getElementById("search_phrase").value = mVal;
    }
}
/* Restore radio button state */
function set_radio_button() {
    var json_string = sessionStorage.getItem("MapicsHistory");
    if (json_string == null) {
        return null;
    }
    var json_obj = JSON.parse(json_string);
    var cookie_page_title = json_obj.page_title;
    var html_page_title = document.getElementById("page-title").innerHTML;
    if (cookie_page_title != html_page_title) {
        return null;
    }
    var radio_btns = document.getElementsByClassName("radio_btn");
    var selected_option = JSON.parse(sessionStorage.getItem("MapicsHistory")).search_by;
    for (i = 0; i < radio_btns.length; i++) {
        radio_option = radio_btns[i].value;
        if (radio_option == selected_option) {
            console.log("radio_option= " + radio_option);
            console.log("selected_option= " + selected_option);
            radio_btns[i].checked = true;
        }
    }
}

function select_po_controller() {
    var checked_radio_button = document.querySelector('input[name="search_field"]:checked');
    if (checked_radio_button == null) {
        return;
    }
    checked_radio_button_id = checked_radio_button.id;
    var form = document.getElementById("po-search-form");
    if (checked_radio_button_id == "radio_po_num" || checked_radio_button_id == "radio_part_num") {
        console.log("___PO___");
        form.setAttribute("action", "/PO/POSearch/");
    }
    if (checked_radio_button_id == "radio_vendor_id" || checked_radio_button_id == "radio_vendor_name") {
        console.log("___VENDOR___");
        form.setAttribute("action", "/POVendor/POVendorSearch/");
    }

}