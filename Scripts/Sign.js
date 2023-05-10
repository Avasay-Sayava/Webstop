let signUpButton = document.getElementById('signup'),
	signInButton = document.getElementById('signin'),
	container = document.getElementById('container'),
	signIn = {
		form: document.getElementById("in"),
		email: document.getElementById("in-email"),
		password: document.getElementById("in-password"),
		submit: document.getElementById("in-submit")
	},
	signUp = {
		form: document.getElementById("up"),
		name: document.getElementById("up-name"),
		email: document.getElementById("up-email"),
		password: document.getElementById("up-password"),
		confirm: document.getElementById("up-password-confirm"),
		submit: document.getElementById("up-submit")
	};

signUpButton.addEventListener('click', () => {
	container.classList.add("right-panel-active");
	history.pushState({ }, null, "Signup");
	document.title = "Sign Up - Webstop";
});

signInButton.addEventListener('click', () => {
	container.classList.remove("right-panel-active");
	history.pushState({ }, null, "Signin");
	document.title = "Sign In - Webstop";
});

signIn.form.addEventListener("submit", e => {
	if (!Sign.check.email(signIn.email.value)) {
		signIn.submit.labels[0].style.position = "relative";
		signIn.submit.labels[0].style.visibility = "visible";
		e.preventDefault();
	} else if (!Sign.check.password(signIn.password.value)) {
		signIn.submit.labels[0].style.position = "relative";
		signIn.submit.labels[0].style.visibility = "visible";
		e.preventDefault();
	}
});

signUp.form.addEventListener("submit", e => {
	if (!Sign.check.name(signUp.name.value)) {
		signUp.name.labels[0].style.position = "relative";
		signUp.name.labels[0].style.visibility = "visible";
		e.preventDefault();
	} else {
		signUp.name.labels[0].style.position = "absolute";
		signUp.name.labels[0].style.visibility = "hidden";
	}

	if (!Sign.check.email(signUp.email.value) && signUp.email.value != "") {
    console.log(signUp.email.value);
		signUp.email.labels[0].style.position = "relative";
		signUp.email.labels[0].style.visibility = "visible";
		e.preventDefault();
	} else {
		signUp.email.labels[0].style.position = "absolute";
		signUp.email.labels[0].style.visibility = "hidden";
	}

	if (!Sign.check.password(signUp.password.value)) {
		signUp.password.labels[0].style.position = "relative";
		signUp.password.labels[0].style.visibility = "visible";
		e.preventDefault();
	} else {
		signUp.password.labels[0].style.position = "absolute";
		signUp.password.labels[0].style.visibility = "hidden";
	}

	if (signUp.confirm.value != signUp.password.value) {
		signUp.confirm.labels[0].style.position = "relative";
		signUp.confirm.labels[0].style.visibility = "visible";
		e.preventDefault();
	} else {
		signUp.confirm.labels[0].style.position = "absolute";
		signUp.confirm.labels[0].style.visibility = "hidden";
	}
});