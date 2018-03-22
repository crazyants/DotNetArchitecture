import { Component } from "@angular/core";

import { AuthenticationModel } from "../../shared/models/authentication.model";
import { ApplicationService } from "../../shared/services/application.service";
import { AuthenticationService } from "../../shared/services/authentication.service";
import { debug } from "util";

@Component({ selector: "app-login", templateUrl: "./login.component.html" })
export class LoginComponent
{
	authenticationModel = new AuthenticationModel();

	constructor(
		private readonly applicationService: ApplicationService,
		private readonly authenticationService: AuthenticationService
	)
	{
		this.authenticationService.logout();
		this.authenticationModel.login = "admin";
		this.authenticationModel.password = "admin";
	}

	submit()
	{
		this.authenticationService.authenticate(this.authenticationModel);
	}

	authenticated()
	{
		this.authenticationService.getAuthenticated();
	}

	callServerOnlyOnce()
	{
		this.applicationService.get().subscribe(response =>
		{
			alert(response);
		});
	}
}
