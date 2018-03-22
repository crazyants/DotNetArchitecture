import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";

import { AppComponent } from "./app.component";
import { LayoutModule } from "./views/layout/layout.module";
import { ROUTES } from "./app.routes";

@NgModule({
	bootstrap: [AppComponent],
	declarations: [AppComponent],
	imports: [
		BrowserModule,
		RouterModule.forRoot(ROUTES),
		LayoutModule
	]
})
export class AppModule { }