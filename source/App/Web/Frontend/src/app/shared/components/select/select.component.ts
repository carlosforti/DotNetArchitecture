import { Component, Input } from "@angular/core";
import { NG_VALUE_ACCESSOR } from "@angular/forms";
import { AppBaseComponent } from "../base/base.component";
import { OptionModel } from "./option.model";

@Component({
    providers: [{ provide: NG_VALUE_ACCESSOR, useExisting: AppSelectComponent, multi: true }],
    selector: "app-select",
    templateUrl: "./select.component.html"
})
export class AppSelectComponent extends AppBaseComponent {
    @Input() options: OptionModel[];
}
