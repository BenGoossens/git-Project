$form = array(
    'myCheckbox' => true // default to checked
    'firstName' => '',
)

// was the form submitted?
if($_SERVER['REQUEST_METHOD'] == 'POST'){
    // overwrite the form array
    $form['myCheckbox'] = isset($_POST['myCheckbox']);
    $form['firstName'] = $_POST['firstName'];

    // at this point do any validation, if it fails, let the form show
}