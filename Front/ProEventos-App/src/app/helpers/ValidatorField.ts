import { AbstractControl, FormGroup } from "@angular/forms";

export class ValidatorField {
    static MustMatch(controlName: string, matchingControlName: string): any {
        return (group: AbstractControl) => {
            const formGroup = group as FormGroup;
            const control = formGroup.get(controlName);
            const matchingControl = formGroup.get(matchingControlName);
            
            if (control?.errors && !control.errors.mustMatch) {
                return;
            }

            if (control?.value !== matchingControl?.value) {
                matchingControl?.setErrors({ mustMatch: true });
            }
            else {
                matchingControl?.setErrors(null);
            }
        };
    }
}
