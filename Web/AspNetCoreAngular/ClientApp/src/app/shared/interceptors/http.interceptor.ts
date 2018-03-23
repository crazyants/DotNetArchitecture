import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from "@angular/common/http";
import { Injectable, Injector } from "@angular/core";

import { AuthenticationService } from "../services/authentication.service";

@Injectable()
export class CustomHttpInterceptor implements HttpInterceptor
{
	constructor(private readonly injector: Injector) { }

	authenticationService: AuthenticationService;

	intercept(request: HttpRequest<any>, next: HttpHandler)
	{
		this.authenticationService = this.injector.get(AuthenticationService);

		request = request.clone({
			setHeaders: {
				Authorization: `Bearer ${this.authenticationService.getToken()}`
			}
		});

		return next.handle(request);
	}
}