// Get DOM elements related to sign up and sign in
const signUpButton = document.getElementById('signup');
const signInButton = document.getElementById('signin');
const container = document.getElementById('container');

const signIn = {
  form: document.getElementById("in"),
  email: document.getElementById("in-email"),
  password: document.getElementById("in-password"),
  submit: document.getElementById("in-submit")
};

const signUp = {
  form: document.getElementById("up"),
  name: document.getElementById("up-name"),
  email: document.getElementById("up-email"),
  password: document.getElementById("up-password"),
  confirm: document.getElementById("up-password-confirm"),
  submit: document.getElementById("up-submit")
};

/**
 * Hides the label associated with an element.
 * @param {HTMLElement} element - The input element.
 * @param {number} i - The index of the label.
 */
function hideLabel(element, i) {
  element.labels[i].style.position = "absolute";
  element.labels[i].style.visibility = "hidden";
}

/**
 * Shows the label associated with an element.
 * @param {HTMLElement} element - The input element.
 * @param {number} i - The index of the label.
 */
function showLabel(element, i) {
  element.labels[i].style.position = "relative";
  element.labels[i].style.visibility = "visible";
}

// Event listener for sign up button click
signUpButton.addEventListener('click', () => {
  container.classList.add("right-panel-active");
  history.pushState({}, null, "Signup");
  document.title = "Sign Up - Webstop";
});

// Event listener for sign in button click
signInButton.addEventListener('click', () => {
  container.classList.remove("right-panel-active");
  history.pushState({}, null, "Signin");
  document.title = "Sign In - Webstop";
});

// Event listener for sign in form submit
signIn.form.addEventListener("submit", (e) => {
  if (!Sign.check.email(signIn.email.value)) {
    showLabel(signIn.submit, 0);
    e.preventDefault();
  } else if (!Sign.check.password(signIn.password.value)) {
    showLabel(signIn.submit, 0);
    e.preventDefault();
  }
});

// Event listener for sign up form submit
signUp.submit.addEventListener("click", (e) => {
  var flag = true;
  if (!Sign.check.name(signUp.name.value)) {
    showLabel(signUp.name, 0);
    flag = false;
    e.preventDefault();
  } else {
    hideLabel(signUp.name, 0);
  }

  if (!Sign.check.email(signUp.email.value)) {
    showLabel(signUp.email, 0);
    flag = false;
    e.preventDefault();
  } else {
    hideLabel(signUp.email, 0);
  }

  if (!Sign.check.password(signUp.password.value)) {
    showLabel(signUp.password, 0);
    flag = false;
    e.preventDefault();
  } else {
    hideLabel(signUp.password, 0);
  }

  if (signUp.confirm.value !== signUp.password.value) {
    showLabel(signUp.confirm, 0);
    flag = false;
    e.preventDefault();
  } else {
    hideLabel(signUp.confirm, 0);
  }

  if (flag) {
    document.getElementById('terms-and-license').showModal();
    document.getElementById('terms-and-license').scrollTop = 0;
  }
});
