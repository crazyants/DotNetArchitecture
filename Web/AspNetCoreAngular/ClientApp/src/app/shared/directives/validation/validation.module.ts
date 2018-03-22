import { CommonModule } from "@angular/common";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { NgModule } from "@angular/core";

import { CurrencyDirective } from "./currency.directive";
import { DateDirective } from "./date.directive";
import { DecimalDirective } from "./decimal.directive";
import { IntegerDirective } from "./integer.directive";
import { TimeDirective } from "./time.directive";

@NgModule({
	declarations: [
		CurrencyDirective,
		DateDirective,
		DecimalDirective,
		IntegerDirective,
		TimeDirective
	],
	exports: [
		CurrencyDirective,
		DateDirective,
		DecimalDirective,
		IntegerDirective,
		TimeDirective
	],
	imports: [
		CommonModule,
		FormsModule,
		ReactiveFormsModule
	]
})
export class ValidationModule { }